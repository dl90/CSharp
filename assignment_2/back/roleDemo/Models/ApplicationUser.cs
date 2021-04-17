using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace roleDemo.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "Must be less than 30 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Must be Aplhabetical")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Must be less than 30 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Must be Aplhabetical")]
        public string LastName { get; set; }

        public virtual ICollection<Attendee> Attendees { get; set; }
    }
}
