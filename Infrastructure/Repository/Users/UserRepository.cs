using Application.Authentication.Common;
using Application.Authentication.RoleManagement.Models;
using Application.Common.Constants;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Entity;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace Infrastructure.Repository.Users
{
    public class UserRepository(
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        DatabaseContext context,
        SignInManager<User> signInManager) : IUserRepository
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



        public async Task<string> RegisterAsync(User user, string role)
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
                        return ConstantResponses.RegisteredSuccessfully;
                    }
                    throw new Exception($"{ConstantResponses.FailedRegistration} {registeredUser.Errors.FirstOrDefault()?.Description}");
                }
                throw new InvalidOperationException(Errors.DuplicateEmail);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserDTO> LoginAsync(string UserName, string Password)
        {
            try
            {
                var user = await userManager.FindByNameAsync(UserName) ?? throw new InvalidOperationException(Errors.WrongUsername);

                var checkPassword = await userManager.CheckPasswordAsync(user, Password);

                if (!checkPassword)
                {
                    throw new InvalidOperationException(Errors.IncorrectPassword);
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

                        return new UserDTO
                        (
                            Id: user.Id,
                            FirstName: user.FirstName,
                            LastName: user.LastName,
                            UserName: user.UserName!,
                            Email: user.Email!
                        );
                    }
                }
                throw new InvalidOperationException(Errors.SignInFailure);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }

        public async Task<UserDTO> GetUserByIdAsync(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            if (user == null)
                return null!;
            return new UserDTO(
                Id: user.Id,
                FirstName: user.FirstName,
                LastName: user.LastName,
                UserName: user.UserName!,
                Email: user.Email!
                );
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var listUsers = await context.Users.Select(u => new UserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName!,
                Email = u.Email!
            }).AsNoTracking().ToListAsync();
                

            return  listUsers;
        }

        public async Task<string> MakeAdminAsync(UpdatePermissions model)
        {
            try
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if(user is null)
                {
                    return ConstantResponses.UsernameNotFound;
                }

                await userManager.AddToRoleAsync(user, UserRoles.ADMIN);
                return $"{model.Username}" + ConstantResponses.NewAdmin;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> MakeSuperAdminAsync(UpdatePermissions model)
        {
            try
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if (user is null)
                {
                    return ConstantResponses.UsernameNotFound;
                }
                await userManager.AddToRoleAsync(user, UserRoles.SUPERADMIN);
                return $"{model.Username}" + ConstantResponses.NewSuperAdmin;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> MakeSuperUserAsync(UpdatePermissions model)
        {
            try
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if(user is null)
                {
                    return ConstantResponses.UsernameNotFound;
                }
                await userManager.AddToRoleAsync(user, UserRoles.SUPERUSER);
                return model.Username + ConstantResponses.NewSuperUser;

            }
            catch (Exception)
            {

                throw;
            }
        }

        
        public async Task<IEnumerable<IdentityRole>> GetRolesAsync()
        {
            return await roleManager.Roles.ToListAsync();
        }
    }
}
