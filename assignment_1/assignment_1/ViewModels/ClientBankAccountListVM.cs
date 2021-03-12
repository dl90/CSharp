using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace assignment_1.ViewModels
{
    public class ClientBankAccountListVM
    {
        [Required]
        [DisplayName("Account Number")]
        [Range(0, Int32.MaxValue)]
        public int AccountNum { get; set; }

        [Required]
        [DisplayName("Account Type")]
        public string AccountType { get; set; }

        [Required]
        [DisplayName("Client ID")]
        [Range(0, Int32.MaxValue)]
        public int ClientID { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "At least 1 letter")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "At least 1 letter")]
        public string FirstName { get; set; }
    }
}
