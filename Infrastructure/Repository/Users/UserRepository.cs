using Application.Authentication.Common;
using Application.Common.Constants;
using Application.Common.Interfaces.Persistence;
using Domain.Entity;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace Infrastructure.Repository.Users
{
    public class UserRepository(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, DatabaseContext context, SignInManager<User> signInManager) : IUserRepository
    {
        public User? GetUserByEmail(string email)
        {
            return context.Users.SingleOrDefault(u => u.Email == email);
        }
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

				if(registeredUser.Succeeded)
				{
					await userManager.AddToRoleAsync(newUser, role);
					return ConstantResponses.RegisteredSuccessfully ;
				}

                throw new Exception($"{ConstantResponses.FailedRegistration} {registeredUser.Errors.FirstOrDefault()?.Description}");
            }
			catch (Exception)
			{

				throw;
			}
        }

        public async Task<User> LoginAsync(string UserName, string Password)
        {
            var user = await userManager.FindByNameAsync(UserName);
            var signIn = await signInManager.PasswordSignInAsync(user!, Password, false, true);

            if (signIn.Succeeded)
            {
                if(user != null && await userManager.CheckPasswordAsync(user, Password))
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

                    return user;
                }
            }
            throw new Exception();
        }



    }
}
