using System;
using System.Collections.Generic;

#nullable disable

namespace _FoodStoreMVCStarter.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Products = new HashSet<Product>();
        }

        public string Mfg { get; set; }
        public decimal? MfgDiscount { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
