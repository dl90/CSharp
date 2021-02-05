using FoodStoreMVCStarter.Models;
using FoodStoreMVCStarter.Repositories;
using FoodStoreMVCStarter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace FoodStoreMVCStarter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly FoodStoreContext ctx;

        //public HomeController()
        //{
            // ctx = new FoodStoreContext();
        //}

        public IActionResult Index()
        {
            var ctx = new FoodStoreContext();
            var products = from p in ctx.Products
                           select p;
            return View(products);
        }

        public IActionResult CustomerStoreBuilding()
        {
            var ctx = new FoodStoreContext();
            // store employee buildling
            var employeeStore = from e in ctx.Employees
                                from s in ctx.Stores
                                where e.Branch == s.Branch
                                select new EmployeeStoreVM()
                                {
                                    LastName = e.LastName,
                                    FirstName = e.FirstName,
                                    Branch = e.Branch,

                                    Region = s.Region,
                                    BuildingName = s.BuildingName ?? "",
                                    UnitNum = s.UnitNum ?? 0
                                };

            var esBuilding = from es in employeeStore
                             from b in ctx.Buildings
                             where es.BuildingName == b.BuildingName
                                   && es.UnitNum == b.UnitNum
                             select new EmployeeStoreBuildingVM()
                             {
                                 LastName = es.LastName,
                                 FirstName = es.FirstName,
                                 Branch = es.Branch,
                                 Region = es.Region,
                                 BuildingName = es.BuildingName,
                                 UnitNum = es.UnitNum,

                                 Capacity = b.Capacity
                             };

            return View(esBuilding);
        }

        [HttpGet]
        public IActionResult Customer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Customer(CustomerVM customer)
        {
            ViewBag.ErrorMessage = "";

            // ModelState.IsValid performs server side validation.
            // *ALWAYS* perform server side validation.
            if (ModelState.IsValid)
            {
                // model is valid...
                // do something like save object and redirt to another page
                return RedirectToAction("Index", "Home");
            }
            else
                ViewBag.ErrorMessage = "This entry is invalid.";
            // return view with errors
            return View(customer);
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
