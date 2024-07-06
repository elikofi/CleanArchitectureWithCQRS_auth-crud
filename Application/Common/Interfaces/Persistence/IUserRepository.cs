using Application.Authentication.Common;
using Domain.Entity;



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
        Task<string> MakeAdminAsync();
        Task<string> MakeSuperAdminAsync();
        Task<string> MakeSuperUserAsync();
        Task<object> GetUserRoles(string email);


        

    }
}
