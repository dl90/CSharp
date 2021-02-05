using FoodStoreMVCStarter.Models;
using FoodStoreMVCStarter.ViewModels;
using System.Linq;

namespace FoodStoreMVCStarter.Repositories
{
    public class StoreBuildingVMRepo
    {
        readonly FoodStoreContext db;

        public StoreBuildingVMRepo(FoodStoreContext context)
        {
            db = context;
        }

        public IQueryable<StoreBuildingVM> GetAll()
        {
            var query = from s in db.Stores
                        from b in db.Buildings
                        where
                            s.BuildingName == b.BuildingName 
                            && s.UnitNum == b.UnitNum
                        select new StoreBuildingVM()
                        {
                            Branch = s.Branch,
                            Region = s.Region,
                            BuildingName = s.BuildingName,
                            UnitNum = s.UnitNum ?? 0,
                            Capacity = b.Capacity ?? 0
                        };

            var buildingJoin = from b in db.Buildings
                               from s in db.Stores
                               .Where(store => 
                                    store.BuildingName == b.BuildingName 
                                    && store.UnitNum == b.UnitNum)
                               .DefaultIfEmpty()
                               select new StoreBuildingVM()
                               {
                                   Branch = s.Branch ?? "",
                                   Region = s.Region ?? "",
                                   BuildingName = b.BuildingName,
                                   UnitNum = b.UnitNum,
                                   Capacity = b.Capacity ?? 0
                               };

            return buildingJoin;
        }

        public StoreBuildingVM Get(string branch, string buildingName, int unitNum)
        {
            return GetAll()
                .Where(sb => 
                    sb.Branch == branch 
                    && sb.BuildingName == buildingName 
                    && sb.UnitNum == unitNum)
                .FirstOrDefault();
        }

        public bool Update(StoreBuildingVM sbVM)
        {
            BuildingRepo buildingRepo = new BuildingRepo(db);
            return buildingRepo.Update(sbVM.BuildingName, sbVM.UnitNum, sbVM.Capacity);
        }
    }
}
