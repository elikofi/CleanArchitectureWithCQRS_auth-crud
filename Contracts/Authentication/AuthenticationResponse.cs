

using Domain.Entity;

namespace Contracts.Authentication
{
    public record AuthenticationResponse(
        string Id,
        string FirstName,
        string LastName,
        string Email,
        //User User,
        string Token);
}
