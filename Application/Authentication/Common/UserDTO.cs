namespace Application.Authentication.Common
{
    public record UserDTO(string Id,
        string FirstName,
        string LastName,
        string UserName,
        string Email);

    public class UserDto
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
    }
}
