using Application.Authentication.Common;
using Application.Common.Constants;
using Application.Common.Interfaces.Persistence;
using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;


namespace Infrastructure.Repository.Users
{
    public class UserRepository(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, DatabaseContext context, IConfiguration configuration) : IUserRepository
    {
        public User? GetUserByEmail(string email)
        {
            return context.Users.SingleOrDefault(u => u.Email == email);
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
            catch (Exception )
            {
				throw;
            }
        }


        //SEED ROLES


    }
}
