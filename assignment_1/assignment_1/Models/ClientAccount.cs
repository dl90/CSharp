using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment_1.Models
{
    public class ClientAccount
    {
        [Key, Column(Order = 0)]
        [Required]
        public int ClientID { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        public int AccountNum { get; set; }

        public virtual Client Client { get; set; }
        public virtual BankAccount BankAccount { get; set; }
    }
}
