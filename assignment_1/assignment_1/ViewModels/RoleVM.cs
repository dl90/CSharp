using System.ComponentModel.DataAnnotations;

namespace assignment_1.ViewModels
{
    public class RoleVM
    {
        [Key]
        [Required]
        [RegularExpression(@"^[A-Z][a-z]+$")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Role Name")]
        [RegularExpression(@"^[A-Z][a-z]+$")]
        public string RoleName { get; set; }
    }
}
