using System.ComponentModel.DataAnnotations;

namespace roleDemo.ViewModels.Auth
{
    public class RegisterVM
    {
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [RegularExpression(@"^[A-Za-z0-9\-_]+$")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "Must be less than 30 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Must be Aplhabetical")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Must be less than 30 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Must be Aplhabetical")]
        public string LastName { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
