using System.ComponentModel.DataAnnotations;

namespace assignment_1.ViewModels
{
    public class UserRoleVM
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
