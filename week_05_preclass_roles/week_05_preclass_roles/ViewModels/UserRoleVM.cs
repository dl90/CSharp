using System.ComponentModel.DataAnnotations;

namespace week_05_preclass_roles.ViewModels
{
    public class UserRoleVM
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
