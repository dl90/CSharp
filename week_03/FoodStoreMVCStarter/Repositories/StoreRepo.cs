using FoodStoreMVCStarter.Models;
using System.Linq;

namespace FoodStoreMVCStarter.Repositories
{
    public class StoreRepo
    {
        readonly FoodStoreContext db;

        public StoreRepo(FoodStoreContext context)
        {
            db = context;
        }

        public bool Update(string branch, string region)
        {
            Store store = db.Stores.Where(s => s.Branch == branch).FirstOrDefault();
            if (store == null) return false;
            store.Region = region;
            db.SaveChanges();

            // Error handling code goes here.
            return true;
        }
    }

}
