using Application.Authentication.Common;
using Domain.Entity;

namespace Contracts.Authentication
{
    public record AuthenticationResponse(
        UserDTO UserDTO,
        string Token);
}   
