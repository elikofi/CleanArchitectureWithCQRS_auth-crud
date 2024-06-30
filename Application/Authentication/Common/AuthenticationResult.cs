using Domain.Entity;


namespace Application.Authentication.Common
{
    //public record AuthenticationResult(User User, string Token);
    public record AuthenticationResult(UserDTO User,    
        string Token);
}
