using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace week_04.Controllers
{
    public class SessionController : Controller
    {
        const string COLOUR_KEY = "Favourite Color Key";
        const string SESSION_START_KEY = "Expiry Date Key";
        const string FIRST_NAME = "FNAME";

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString(COLOUR_KEY) == null &&
                HttpContext.Session.GetString(FIRST_NAME) == null)
            {
                string favouriteColour = "Green";
                ViewBag.Color = favouriteColour;
                HttpContext.Session.SetString(COLOUR_KEY, favouriteColour);

                string fName = "Don Initial";
                ViewBag.FName = fName;
                HttpContext.Session.SetString(FIRST_NAME, fName);

                string now = DateTime.Now.ToString();
                ViewBag.SessionStart = now;
                HttpContext.Session.SetString(SESSION_START_KEY, now);
            }
            else
            {
                string fName = "Don";
                ViewBag.FName = fName;
                HttpContext.Session.SetString(FIRST_NAME, fName);

                string inProgressColour = "Blue";
                ViewBag.Color = inProgressColour;
                HttpContext.Session.SetString(COLOUR_KEY, inProgressColour);
            }

            ViewBag.FName = HttpContext.Session.GetString(FIRST_NAME);
            ViewBag.Color = HttpContext.Session.GetString(COLOUR_KEY);
            ViewBag.SessionStart = HttpContext.Session.GetString(SESSION_START_KEY);
            return View();
        }
        public IActionResult About()
        {
            HttpContext.Session.Clear();
            return View();
        }
    }
}
