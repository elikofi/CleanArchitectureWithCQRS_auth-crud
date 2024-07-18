using Application.Authentication.Common;
using Application.Authentication.RoleManagement.Models;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;



namespace Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        //User Management
        Task<string> RegisterAsync(User user, string role);
        Task<UserDTO> LoginAsync(string UserName, string Password); 
        User? GetUserByEmail(string email);
        Task<UserDTO> GetUserByIdAsync(string Id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();


        //role management
        Task<string> SeedRoles();
        Task<string> MakeAdminAsync(UpdatePermissions model);
        Task<string> MakeSuperAdminAsync(UpdatePermissions model);
        Task<string> MakeSuperUserAsync(UpdatePermissions model);
        Task<IEnumerable<IdentityRole>> GetRolesAsync();    


        

    }
}
