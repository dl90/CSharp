using System;
using System.Collections.Generic;

#nullable disable

namespace _FoodStoreMVCStarter.Models
{
    public partial class Building
    {
        public Building()
        {
            Stores = new HashSet<Store>();
        }

        public string BuildingName { get; set; }
        public int UnitNum { get; set; }
        public int? Capacity { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
