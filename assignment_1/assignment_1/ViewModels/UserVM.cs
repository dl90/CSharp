using System.ComponentModel.DataAnnotations;

namespace assignment_1.ViewModels
{
    public class UserVM
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string ID { get; set; }
    }
}
