using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using roleDemo.Data;
using roleDemo.Repositories;
using roleDemo.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace roleDemo.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserRoleController : Controller
    {
        private IServiceProvider _serviceProvider;
        private UserRepo _userRepo;
        private RoleRepo _roleRepo;
        private UserRoleRepo _userRoleRepo;

        public UserRoleController(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _userRepo = new UserRepo(context);
            _roleRepo = new RoleRepo(context);
            _userRoleRepo = new UserRoleRepo(_serviceProvider);
        }

        public ActionResult Index()
        {
            var users = _userRepo.All();
            return View(users);
        }

        public async Task<IActionResult> Detail(string userName)
        {
            var roles = await _userRoleRepo.GetUserRoles(userName);
            ViewBag.UserName = userName;
            return View(roles);
        }

        public ActionResult Create(string userName)
        {
            ViewBag.SelectedUser = userName;
            var roles = _roleRepo.GetAllRoles().ToList();

            var preRoleList = roles.Select(r => new SelectListItem { Value = r.RoleName, Text = r.RoleName }).ToList();
            ViewBag.RoleSelectList = new SelectList(preRoleList, "Value", "Text"); ;

            var userList = _userRepo.All();
            var preUserList = userList.Select(u => new SelectListItem
                { Value = u.UserName, Text = u.UserName }).ToList();
            ViewBag.UserSelectList = new SelectList(preUserList, "Value", "Text");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRoleVM userRoleVM)
        {
            if (ModelState.IsValid)
            {
                var addUR = await _userRoleRepo.AddUserRole(userRoleVM.UserName, userRoleVM.Role);
            }
            try
            {
                return RedirectToAction("Detail", "UserRole",
                       new { userName = userRoleVM.UserName });
            }
            catch
            {
                return View();
            }
        }
    }

}
