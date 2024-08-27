using Application.Authentication.Common;
using Application.Authentication.RoleManagement.Models;
using Application.Common.Results;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;



namespace Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        //User Management
        Task<Result<string>> RegisterAsync(User user, string role);
        Task<Result<UserDTO>> LoginAsync(string UserName, string Password); 
        Task<Result<UserDTO>> GetUserByIdAsync(string Id);
        Task<Result<IEnumerable<UserDTO>>> GetAllUsersAsync();


        //role management
        Task<string> SeedRoles();
        Task<Result<string>> MakeAdminAsync(UpdatePermissions model);
        Task<Result<string>> MakeSuperAdminAsync(UpdatePermissions model);
        Task<Result<string>> MakeSuperUserAsync(UpdatePermissions model);
        Task<Result<IEnumerable<IdentityRole>>> GetRolesAsync();    


        

    }
}
