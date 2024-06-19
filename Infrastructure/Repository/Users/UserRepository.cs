using Application.Common.Interfaces.Persistence;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Users
{
    public class UserRepository(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration) : IUserRepository
    {
        public Task<User> RegisterAsync(User user, string role)
        {
            throw new NotImplementedException();
        }
    }
}
