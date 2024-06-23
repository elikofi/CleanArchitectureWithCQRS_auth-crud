using Application.Authentication.Common;
using Domain.Entity;



namespace Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<string> RegisterAsync(User user, string role);
        User? GetUserByEmail(string email);

        //role management
        Task<string> SeedRoles();


        

    }
}
