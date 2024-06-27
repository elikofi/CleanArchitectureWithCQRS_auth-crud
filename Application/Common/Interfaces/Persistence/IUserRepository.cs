
using Domain.Entity;



namespace Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<string> RegisterAsync(User user, string role);
        Task<User> LoginAsync(string UserName, string Password);
        User? GetUserByEmail(string email);

        //role management
        Task<string> SeedRoles();


        

    }
}
