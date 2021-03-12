using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using roleDemo.Data;
using roleDemo.Models;
using roleDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace roleDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult SecureArea()
        {
            // Get user name of user who is logged in.
            // This line must be in the controller.
            string userName = User.Identity.Name;
            ViewBag.userName = userName;
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("test")]
        public IActionResult Handler([FromBody] TestVM test)
        {
            var claim = HttpContext.User.Claims.ElementAt(0);
            string userName = claim.Value;
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return new ObjectResult(new { test.FirstName, test.LastName, userId });
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
