using System.ComponentModel.DataAnnotations;

namespace Application.Authentication.RoleManagement.Models
{
    public class UpdatePermissions
    {
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; } = string.Empty;
    }
}
