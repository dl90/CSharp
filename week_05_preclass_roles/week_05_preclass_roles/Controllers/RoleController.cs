using Microsoft.AspNetCore.Mvc;
using week_05_preclass_roles.Data;
using week_05_preclass_roles.Repositories;
using week_05_preclass_roles.ViewModels;

namespace week_05_preclass_roles.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext _context;

        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            RoleRepo roleRepo = new RoleRepo(_context);
            return View(roleRepo.GetAllRoles());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoleVM roleVM)
        {
            if (ModelState.IsValid)
            {
                RoleRepo roleRepo = new RoleRepo(_context);
                var success = roleRepo.CreateRole(roleVM.RoleName);
                if (success) return RedirectToAction(nameof(Index));
            }
            ViewBag.Error = "An error occurred while creating this role. Please try again.";
            return View();
        }
    }
}
