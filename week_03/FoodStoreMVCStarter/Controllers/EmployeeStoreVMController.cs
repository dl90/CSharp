using FoodStoreMVCStarter.Models;
using FoodStoreMVCStarter.Repositories;
using FoodStoreMVCStarter.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodStoreMVCStarter.Controllers
{
    public class EmployeeStoreVMController : Controller
    {
        private readonly FoodStoreContext ctx;
        private readonly EmployeeStoreVMRepo esRepo;

        public EmployeeStoreVMController() {
            ctx = new FoodStoreContext();
            esRepo = new EmployeeStoreVMRepo(ctx);
        }

        public IActionResult Index()
        {
            var query = esRepo.GetAll();
            return View(query);
        }

        public IActionResult Details(int employeeID, string branch)
        {
            EmployeeStoreVM esVM = esRepo.Get(employeeID, branch);
            return View(esVM);
        }

        [HttpGet]
        public IActionResult Edit(int employeeID, string branch)
        {
            EmployeeStoreVM esVM = esRepo.Get(employeeID, branch);
            return View(esVM);
        }

        // This method is called when the user clicks the submit
        // button from the edit page.
        [HttpPost]
        public IActionResult Edit(EmployeeStoreVM esVM)
        {
            esRepo.Update(esVM);

            // go to index action method of the EmployeeStore controller.
            return RedirectToAction("Index", "EmployeeStoreVM");
        }
    }
}
