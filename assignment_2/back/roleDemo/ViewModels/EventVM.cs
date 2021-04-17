using System;
using System.ComponentModel.DataAnnotations;

namespace roleDemo.ViewModels
{
    public class EventVM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Must be less than 30 characters")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(512)]
        public string Description { get; set; }
    }
}
