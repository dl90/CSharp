using FoodStoreMVCStarter.Models;
using System.Linq;

namespace FoodStoreMVCStarter.Repositories
{
    public class BuildingRepo
    {
        readonly FoodStoreContext db;

        public BuildingRepo(FoodStoreContext context)
        {
            db = context;
        }

        public bool Update(string buildingName, int unitNum, int capacity)
        {
            Building b = db.Buildings.Where(b =>
                b.BuildingName == buildingName && b.UnitNum == unitNum)
                .FirstOrDefault();
            if (b == null || capacity < 0) return false;
            b.Capacity = capacity;
            var entries = db.SaveChanges();
            return entries == 1;
        }
    }
}
