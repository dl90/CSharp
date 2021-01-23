using Microsoft.AspNetCore.Mvc;
using System.Linq;
using week_01.Models;
using System.Text.RegularExpressions;

namespace week_01.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            FoodStoreContext db = new FoodStoreContext();
            var stores = from s in db.Stores
                         where s.Region == "BC"
                         select s;
            var res = from s in stores.AsEnumerable()
                      where Regex.IsMatch(s.Branch, "^(K|L|M)") == true
                      select s;
            return View(res);
        }

        [Route("Store/Details/{branchName}")]
        public IActionResult Details(string? branchName)
        {
            FoodStoreContext db = new FoodStoreContext();
            Store store = (from s in db.Stores
                         where s.Branch == branchName
                         select s).FirstOrDefault();
            return View(store);
        }
    }
}
