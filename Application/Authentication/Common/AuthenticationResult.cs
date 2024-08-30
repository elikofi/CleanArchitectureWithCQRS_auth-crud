namespace Application.Authentication.Common
{
    public record AuthenticationResult(UserDTO User, string Token);
}
