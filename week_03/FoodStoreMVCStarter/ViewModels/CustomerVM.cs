using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodStoreMVCStarter.ViewModels
{
    public class CustomerVM
    {
        [Required(ErrorMessage = "First name required.")]
        [StringLength(50, ErrorMessage = "Name must be maximum of 50 characters.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "First name required.")]
        public string LastName { get; set; }

        [Range(0, 4, ErrorMessage = "Total tickets must be between 1 and 4.")]
        [Required(ErrorMessage = "A ticket quantity is required.")]
        public int TotalTickets { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A birthday is required.")]
        public DateTime Birthday { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email Address")]
        [Required(ErrorMessage = "An email address is required.")]
        public string Email { get; set; }

        [DisplayName("Postal Code")]
        [RegularExpression("[A-Z][0-9][A-Z] ?[0-9][A-Z][0-9]",
                            ErrorMessage = "This is not a valid Canadian postal code.")]
        public string Postal { get; set; }

    }
}
