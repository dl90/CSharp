using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace assignment_1.Models
{
    public class BankAccount
    {
        [Key]
        [Required]
        public int AccountNum { get; set; }

        [Required]
        public string AccountType { get; set; }

        [Required]
        [Range(0, Double.MaxValue)]
        [RegularExpression(@"^\d+.\d{0,2}$")]
        public decimal Balance { get; set; }

        public virtual ICollection<ClientAccount> ClientAccounts { get; set; }
    }
}
