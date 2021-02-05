using FoodStoreMVCStarter.Models;
using System.Linq;

namespace FoodStoreMVCStarter.Repositories
{
    public class EmployeeRepo
    {
        readonly FoodStoreContext db;

        public EmployeeRepo(FoodStoreContext context)
        {
            db = context;
        }

        public bool Update(int id, string first, string last)
        {
            Employee employee = db.Employees
                .Where(e => e.EmployeeId == id).FirstOrDefault();

            if (employee == null) return false;
            employee.FirstName = first;
            employee.LastName = last;
            db.SaveChanges();
            return true;
        }
    }
}
