using Domain.Entity;

namespace Contracts.Authentication
{
    public record AuthenticationResponse(
        string Id,
        string Email,
        string FirstName,
        string LastName,
        string UserName,
        string Token);
}
