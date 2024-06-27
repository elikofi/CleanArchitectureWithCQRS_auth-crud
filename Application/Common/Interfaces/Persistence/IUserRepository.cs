
using Domain.Entity;



namespace Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<string> RegisterAsync(User user, string role);
        Task<User> LoginAsync(string UserName, string Password);
        User? GetUserByEmail(string email);
        Task<User> GetUserById(string Id);

        //role management
        Task<string> SeedRoles();


        

    }
}
