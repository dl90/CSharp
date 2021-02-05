using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace week_04.ViewModels
{
    public class SiteUserVM
    {
        [DisplayName("Enter Value for the 'First Name' Cookie")]
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "2-30 chars")]
        public string FirstName { get; set; }

        [DisplayName("Last Name Cookie")]
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "2-30 chars")]
        public string LastName { get; set; }
    }
}
