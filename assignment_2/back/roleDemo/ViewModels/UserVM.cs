using System.ComponentModel.DataAnnotations;

namespace roleDemo.ViewModels
{
    public class UserVM
    {
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string UserName { get; set; }

        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "Must be less than 30 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Must be Aplhabetical")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Must be less than 30 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Must be Aplhabetical")]
        public string LastName { get; set; }
    }
}
