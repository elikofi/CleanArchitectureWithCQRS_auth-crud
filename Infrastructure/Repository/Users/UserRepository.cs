using Application.Authentication.Common;
using Application.Authentication.RoleManagement.Models;
using Application.Common.Constants;
using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using Domain.Common.Errors;
using Domain.Entity;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;


namespace Infrastructure.Repository.Users
{
    public class UserRepository(
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        DatabaseContext context,
        SignInManager<User> signInManager,
        ILogger<UserDTO> logger) : IUserRepository
    {
        public async Task<string> SeedRoles()
        {
            try
            {
                bool isSuperAdminRoleExists = await roleManager.RoleExistsAsync(UserRoles.SUPERADMIN);
                bool isAdminRoleExists = await roleManager.RoleExistsAsync(UserRoles.ADMIN);
                bool isUserRoleExists = await roleManager.RoleExistsAsync(UserRoles.USER);
                bool isSuperUserRoleExists = await roleManager.RoleExistsAsync(UserRoles.SUPERUSER);

                if (isSuperAdminRoleExists && isAdminRoleExists && isUserRoleExists && isSuperUserRoleExists)
                {
                    return "Roles seeding already done.";
                }


                await roleManager.CreateAsync(new IdentityRole(UserRoles.SUPERADMIN));
                await roleManager.CreateAsync(new IdentityRole(UserRoles.ADMIN));
                await roleManager.CreateAsync(new IdentityRole(UserRoles.USER));
                await roleManager.CreateAsync(new IdentityRole(UserRoles.SUPERUSER));

                return "seeded roles.!";
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<Result<string>> RegisterAsync(User user, string role)
        {
            try
            {
                var userExists = await userManager.FindByEmailAsync(user.Email!);
                if (userExists == null)
                {

                    User newUser = new()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        UserName = user.UserName,
                        EmailConfirmed = true,
                        TwoFactorEnabled = false,
                        SecurityStamp = Guid.NewGuid().ToString()

                    };

                    var registeredUser = await userManager.CreateAsync(newUser, user.PasswordHash!);

                    if (registeredUser.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newUser, role);
                        return Result<string>.SuccessResult(ConstantResponses.RegisteredSuccessfully);
                    }
                    return Result<string>.ErrorResult($"{ConstantResponses.FailedRegistration} {registeredUser.Errors.FirstOrDefault()?.Description}");
                }
                return Result<string>.ErrorResult(Errors.DuplicateEmail);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Result<UserDTO>> LoginAsync(string UserName, string Password)
        {
            try
            {
                var user = await userManager.FindByNameAsync(UserName);
                if(user is null)
                {
                    return Result<UserDTO>.ErrorResult(Errors.WrongUsername);
                }

                var checkPassword = await userManager.CheckPasswordAsync(user, Password);

                if (!checkPassword)
                {
                    return Result<UserDTO>.ErrorResult(Errors.IncorrectPassword);
                }


                var signIn = await signInManager.PasswordSignInAsync(user!, Password, false, true);

                if (signIn.Succeeded)
                {
                    if (user != null && await userManager.CheckPasswordAsync(user, Password))
                    {
                        var userRoles = await userManager.GetRolesAsync(user);

                        var authClaims = new List<Claim>
                    {
                        new(ClaimTypes.Name, user.UserName!),
                        new(ClaimTypes.NameIdentifier, user.Id),
                    };

                        foreach (var userRole in userRoles)
                        {
                            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                        }

                        return Result<UserDTO>.SuccessResult( new UserDTO
                        (
                            Id: user.Id,
                            FirstName: user.FirstName,
                            LastName: user.LastName,
                            UserName: user.UserName!,
                            Email: user.Email!)
                        );
                    }
                }
                return Result<UserDTO>.ErrorResult(Errors.SignInFailure);
            }
            //catch (InvalidOperationException ex)
            //{
            //    logger.LogError(ex, Errors.SignInFailure);
            //    throw; 
            //}
            catch (Exception ex)
            {
                logger.LogError(ex, Errors.SignInFailure);
                throw;
            }

        }

        public async Task<Result<UserDTO>> GetUserByIdAsync(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return Result<UserDTO>.ErrorResult(ConstantResponses.UserNotFound);
            }
            return Result<UserDTO>.SuccessResult(
                new UserDTO(
                    Id: user.Id,
                    FirstName: user.FirstName,
                    LastName: user.LastName,
                    UserName: user.UserName!,
                    Email: user.Email!)
                );
        }

        public async Task<Result<IEnumerable<UserDTO>>> GetAllUsersAsync()
        {
            try
            {
                var listUsers = await context.Users
                .AsNoTracking()
                .Select(u => new UserDTO(
                    u.Id,
                    u.FirstName,
                    u.LastName,
                    u.UserName ?? string.Empty,
                    u.Email ?? string.Empty
                ))
                .ToListAsync();

                if (!listUsers.Any())
                {
                    return Result<IEnumerable<UserDTO>>.ErrorResult(ConstantResponses.NoUsersInDB);
                }

                return Result<IEnumerable<UserDTO>>.SuccessResult(listUsers);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<Result<string>> MakeAdminAsync(UpdatePermissions model)
        {
            try
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if(user is null)
                {
                    return Result<string>.ErrorResult( ConstantResponses.UsernameNotFound);
                }

                await userManager.AddToRoleAsync(user, UserRoles.ADMIN);
                return Result<string>.SuccessResult($"{model.Username}" + ConstantResponses.NewAdmin);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Result<string>> MakeSuperAdminAsync(UpdatePermissions model)
        {
            try
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if (user is null)
                {
                    return Result<string>.ErrorResult(ConstantResponses.UsernameNotFound);
                }
                await userManager.AddToRoleAsync(user, UserRoles.SUPERADMIN);

                return Result<string>.SuccessResult($"{model.Username}" + ConstantResponses.NewSuperAdmin);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Result<string>> MakeSuperUserAsync(UpdatePermissions model)
        {
            try
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if(user is null)
                {
                    return Result<string>.ErrorResult(ConstantResponses.UsernameNotFound);
                }
                await userManager.AddToRoleAsync(user, UserRoles.SUPERUSER);
                return Result<string>.SuccessResult(model.Username + ConstantResponses.NewSuperUser);

            }
            catch (Exception)
            {

                throw;
            }
        }

        
        public async Task<Result<IEnumerable<IdentityRole>>> GetRolesAsync()
        {
            var roles = await roleManager.Roles.ToListAsync();

            return Result<IEnumerable<IdentityRole>>.SuccessResult(roles);
        }
    }
}
