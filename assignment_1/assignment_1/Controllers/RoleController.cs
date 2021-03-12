using assignment_1.Data;
using assignment_1.Repositories;
using assignment_1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace assignment_1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleRepo _roleRepo;

        public RoleController(ApplicationDbContext context)
        {
            _context = context;
            _roleRepo = new RoleRepo(_context);
        }

        public IActionResult Index()
        {
            return View(_roleRepo.GetAllRoles());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoleVM roleVM)
        {
            if (ModelState.IsValid)
            {
                var success = _roleRepo.CreateRole(roleVM.RoleName);
                if (success) return RedirectToAction(nameof(Index));
            }
            ViewBag.Error = "An error occurred while creating this role. Please try again.";
            return View();
        }

        public IActionResult Edit(RoleVM roleVM)
        {
            return View(roleVM);
        }

        [HttpPost]
        public IActionResult Update(RoleVM roleVM)
        {
            if (ModelState.IsValid) _roleRepo.UpdateRole(roleVM);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(RoleVM roleVM)
        {
            _roleRepo.DeleteRole(roleVM.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
