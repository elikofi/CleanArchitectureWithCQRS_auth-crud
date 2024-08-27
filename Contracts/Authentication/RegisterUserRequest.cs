
namespace Contracts.Authentication
{
    public record RegisterUserRequest(
        string FirstName,
        string LastName,
        string Email,
        string UserName,
        string PasswordHash
        );
}
