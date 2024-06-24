using Domain.Entity;

namespace Contracts.Authentication
{
    public record AuthenticationResponse(
        //User User,
        string Id,
        string Email,
        string FirstName,
        string LastName,
        string UserName,
        string Token);
}
