using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace week_11_preclass_azure.ViewModels
{
    public class ProduceSupplierJoinedVM
    {
        [Required]
        [Range(0, Int32.MaxValue)]
        [DisplayName("Produce ID")]
        public int ProduceID { get; set; }

        [Required]
        [DisplayName("Produce Name")]
        public string ProduceName { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        [DisplayName("Supplier ID")]
        public int SupplierID { get; set; }

        [Required]
        [DisplayName("Supplier Name")]
        public string SupplierName { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int Quantity { get; set; }

    }
}
