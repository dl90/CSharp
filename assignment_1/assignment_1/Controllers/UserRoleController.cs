using assignment_1.Data;
using assignment_1.Repositories;
using assignment_1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserRoleController : Controller
    {
        private ApplicationDbContext _context;
        private IServiceProvider _serviceProvider;
        private UserRepo _userRepo;
        private RoleRepo _roleRepo;
        private UserRoleRepo _userRoleRepo;

        public UserRoleController(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;

            _userRepo = new UserRepo(_context);
            _roleRepo = new RoleRepo(_context);
            _userRoleRepo = new UserRoleRepo(_serviceProvider);
        }

        public ActionResult Index()
        {
            var users = _userRepo.All();
            return View(users);
        }

        public async Task<IActionResult> Detail(string userName)
        {
            UserRoleRepo userRoleRepo = new UserRoleRepo(_serviceProvider);
            var roles = await userRoleRepo.GetUserRoles(userName);
            ViewBag.UserName = userName;
            return View(roles);
        }

        public ActionResult Create(string userName)
        {
            var roles = _roleRepo.GetAllRoles().ToList();
            var preRoleList = roles.Select(r => new SelectListItem { Value = r.RoleName, Text = r.RoleName }).ToList();
            var roleList = new SelectList(preRoleList, "Value", "Text");
            ViewBag.RoleSelectList = roleList;

            var user = _userRepo.FineOne(userName);
            return View(new UserRoleVM { Id = user.ID, Email = user.Email, Role = "" });
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRoleVM userRoleVM)
        {
            if (ModelState.IsValid)
            {
                await _userRoleRepo.AddUserRole(userRoleVM.Email, userRoleVM.Role);
            }

            try
            {
                return RedirectToAction("Detail", "UserRole", new { userName = userRoleVM.Email });
            }
            catch
            {
                return View();
            }
        }
    }
}
