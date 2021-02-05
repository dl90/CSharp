using System.ComponentModel;

namespace FoodStoreMVCStarter.ViewModels
{
    public class EmployeeStoreBuildingVM
    {
        [DisplayName("Employee ID")]
        public int EmployeeId { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Buildling Name")]
        public string BuildingName { get; set; }

        [DisplayName("Unit Number")]
        public int? UnitNum { get; set; }

        public string Branch { get; set; }
        public string Region { get; set; }
        public int? Capacity { get; set; }
    }
}
