using System.ComponentModel.DataAnnotations;

namespace roleDemo.ViewModels
{
    public class UserRoleVM
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Role { get; set; }
    }

}
