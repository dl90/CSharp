using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace assignment_1.Models
{
    public class Client
    {
        [Key]
        [Required]
        public int ClientID { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9_]+@[a-zA-Z0-9]+\.[a-zA-Z]+$")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid input")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid input")]
        public string LastName { get; set; }

        public virtual ICollection<ClientAccount> ClientAccounts { get; set; }
    }
}
