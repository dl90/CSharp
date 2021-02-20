using FoodStoreMVCStarter.Models;
using FoodStoreMVCStarter.ViewModels;
using System.Linq;

namespace FoodStoreMVCStarter.Repositories
{
    public class EmployeeStoreVMRepo
    {
        readonly FoodStoreContext db;

        public EmployeeStoreVMRepo(FoodStoreContext context)
        {
            db = context;
        }

        public IQueryable<EmployeeStoreVM> GetAll()
        {
            var query = from s in db.Stores
                        from e in db.Employees
                        where s.Branch == e.Branch
                        select new EmployeeStoreVM()
                        {
                            Branch = s.Branch,
                            Region = s.Region,
                            EmployeeID = e.EmployeeId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,

                            // Must handle null because a null exists for unit_num in the database.
                            // Get integer if it exists otherwise get 0.
                            UnitNum = s.UnitNum ?? 0,
                            BuildingName = s.BuildingName ?? ""
                        };

            var leftJoin = from s in db.Stores
                           from e in db.Employees
                           .Where(emp => emp.Branch == s.Branch).DefaultIfEmpty()

                           select new EmployeeStoreVM()
                           {
                               // Employee could be null.
                               EmployeeID = (e.EmployeeId != null) ? e.EmployeeId : 0,
                               LastName = e.LastName ?? "",
                               FirstName = e.FirstName ?? "",
                               Branch = s.Branch,
                               Region = s.Region,
                               BuildingName = s.BuildingName ?? "",
                               UnitNum = s.UnitNum ?? 0
                           };
            return query;
        }

        public EmployeeStoreVM Get(int employeeID, string branch)
        {
            // The GetAll() performs the required join and is lazy-loaded
            // so filter it on branch and employeeID.
            return GetAll()
                .Where(es => es.Branch == branch && es.EmployeeID == employeeID)
                .FirstOrDefault();
        }

        public bool Update(EmployeeStoreVM esVM)
        {
            // Updating our ViewModel really requires updates to two separate tables.

            // Update the 'Store'.
            StoreRepo storeRepo = new StoreRepo(db);
            storeRepo.Update(esVM.Branch, esVM.Region);

            // Update the 'Employee'.
            EmployeeRepo empRepo = new EmployeeRepo(db);
            empRepo.Update(esVM.EmployeeID, esVM.FirstName, esVM.LastName);

            // Error handling could go here and if problems are encountered
            // 'false' could be returned.

            // Otherwise if things go well return true.
            return true;
        }
    }
}
