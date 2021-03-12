using System;
using System.ComponentModel.DataAnnotations;

namespace assignment_1.ViewModels
{
    public class ClientBankAccountDetailsVM : ClientBankAccountListVM
    {
        [Required]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9_]+@[a-zA-Z0-9]+\.[a-zA-Z]+$")]
        public string Email { get; set; }

        [Required]
        [Range(0, Double.MaxValue)]
        [RegularExpression(@"^\d+\.\d{2}$", ErrorMessage = "Incorrect fomat, expected 1.23")]
        public decimal Balance { get; set; }
    }
}
