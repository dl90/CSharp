using System.ComponentModel.DataAnnotations;

namespace week_05_preclass_roles.ViewModels
{
    public class RoleVM
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}