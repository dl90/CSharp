using System.ComponentModel;

namespace FoodStoreMVCStarter.ViewModels
{
    public class EmployeeStoreVM
    {
        [DisplayName("Employee ID")]
        public int EmployeeID { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        public string Branch { get; set; }
        public string Region { get; set; }
        [DisplayName("Building Name")]
        public string BuildingName { get; set; }
        [DisplayName("Unit")]
        public int UnitNum { get; set; }
    }
}
