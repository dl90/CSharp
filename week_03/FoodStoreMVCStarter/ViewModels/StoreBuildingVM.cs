using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodStoreMVCStarter.ViewModels
{
    public class StoreBuildingVM
    {
        public string Branch { get; set; }
        public string Region { get; set; }
        [DisplayName("Building Name")]
        public string BuildingName { get; set; }
        [DisplayName("Unit Number")]
        public int UnitNum { get; set; }

        [Range(20, 10000, ErrorMessage = "Capacity must be between 20 and 10000.")]
        public int Capacity { get; set; }
    }
}
