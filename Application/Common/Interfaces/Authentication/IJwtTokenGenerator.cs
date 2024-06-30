using Application.Authentication.Common;
using Domain.Entity;

namespace Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(UserDTO user);
    }
}
