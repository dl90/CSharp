using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using week_04.Services;
using week_04.ViewModels;

namespace week_04.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        // Shows default view and reads cookie if it exists.
        public IActionResult ClearCookie(string key)
        {
            CookieHelper cookieHelper = new CookieHelper(_httpContextAccessor, Request, Response);
            cookieHelper.Remove(key);
            return RedirectToAction("Index", "Home");
        }

        // Let’s user store value in cookie.
        [HttpPost]
        public IActionResult Index(SiteUserVM siteUser)
        {
            CookieHelper cookieHelper = new CookieHelper(_httpContextAccessor, Request, Response);
            const int DAYS_TO_EXPIRE = 1;
            cookieHelper.Set("FirstName", siteUser.FirstName, DAYS_TO_EXPIRE);
            cookieHelper.Set("LastName", siteUser.LastName, DAYS_TO_EXPIRE);

            // Redirect to GET method so cookie is read.
            return RedirectToAction("Index", "Home");
        }

        // Shows default view and reads cookie if it exists.
        [HttpGet]
        public IActionResult Index()
        {
            CookieHelper cookieHelper = new CookieHelper(_httpContextAccessor, Request, Response);
            string firstName = cookieHelper.Get("FirstName");
            string lastName = cookieHelper.Get("LastName");

            if (firstName != null) ViewBag.FirstName = firstName;
            if (lastName != null) ViewBag.LastName = lastName;
            return View();
        }
    }
}
