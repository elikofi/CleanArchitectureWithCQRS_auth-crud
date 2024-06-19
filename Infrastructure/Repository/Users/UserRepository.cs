using Application.Common.Interfaces.Persistence;
using Domain.Entity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;


namespace Infrastructure.Repository.Users
{
    public class UserRepository(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration) : IUserRepository
    {

        public async Task<string> RegisterAsync(User user, string role)
        {
			try
			{
				//check user exists
				var userExists = await userManager.FindByEmailAsync(user.Email!);
				if (userExists != null)
				{
					return "user is alread there";
				}

				var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash, 12);
					

				//var passwordHasher = new BCryptPasswordHasher<User>();

				//var hashedPassword = passwordHasher.HashPassword(user, user.PasswordHash!);


				User newUser = new()
				{
					FirstName = user.FirstName,
					LastName = user.LastName,
					Email = user.Email,
					UserName = user.UserName,
					PasswordHash = hashedPassword,
					EmailConfirmed = true,
					TwoFactorEnabled = false

				};

				var registeredUser = await userManager.CreateAsync(newUser, hashedPassword);

				if(registeredUser is { })
				{
					await userManager.AddToRoleAsync(newUser, role);
					return "user created!";
				}





				return "Unable to create user";
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
