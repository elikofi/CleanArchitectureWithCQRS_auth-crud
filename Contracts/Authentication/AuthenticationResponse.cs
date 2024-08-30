
namespace Contracts.Authentication
{
    public record AuthenticationResponse(
        string Id, 
        string UserName,
        string Email,
        string Token);
}   
