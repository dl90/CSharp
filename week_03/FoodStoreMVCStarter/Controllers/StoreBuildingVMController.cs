using FoodStoreMVCStarter.Models;
using FoodStoreMVCStarter.Repositories;
using FoodStoreMVCStarter.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodStoreMVCStarter.Controllers
{
    public class StoreBuildingVMController : Controller
    {
        private readonly FoodStoreContext ctx;
        private readonly StoreBuildingVMRepo sbRepo;

        public StoreBuildingVMController()
        {
            ctx = new FoodStoreContext();
            sbRepo = new StoreBuildingVMRepo(ctx);
        }

        public IActionResult Index()
        {
            var query = sbRepo.GetAll();
            return View(query);
        }

        public IActionResult Details(string branch, string buildingName, int unitNum)
        {
            StoreBuildingVM sbVM = sbRepo.Get(branch, buildingName, unitNum);
            return View(sbVM);
        }

        [HttpGet]
        public IActionResult Edit(string branch, string buildingName, int unitNum)
        {
            StoreBuildingVM sbVM = sbRepo.Get(branch, buildingName, unitNum);
            return View(sbVM);
        }

        [HttpPost]
        public IActionResult Edit(StoreBuildingVM sbVM)
        {
            ViewBag.ErrorMessage = "";

            if (ModelState.IsValid)
            {
                sbRepo.Update(sbVM);
                return RedirectToAction("Index", "StoreBuildingVM");
            }
            return View(sbVM);
        }
    }
}
