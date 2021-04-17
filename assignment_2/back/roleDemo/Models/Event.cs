using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace roleDemo.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public virtual ICollection<Attendee> Attendees { get; set; }
    }
}
