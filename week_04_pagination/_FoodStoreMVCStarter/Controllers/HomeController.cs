using _FoodStoreMVCStarter.Models;
using _FoodStoreMVCStarter.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;

namespace _FoodStoreMVCStarter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        FoodStoreContext _context = new FoodStoreContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            string nameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["nameSortParm"] = nameSortParam;

            if (sortOrder == "Price") ViewData["priceSortParm"] = "price_desc";
            else ViewData["priceSortParm"] = "Price";

            if (searchString != null) page = 1;
            else searchString = currentFilter;


            IQueryable<Product> products = _context.Products;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case "Price":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                default:
                    products = products.OrderBy(p => p.Name);
                    break;
            }

            int pageSize = 2;
            return View(PaginatedList<Product>.Create(products.AsNoTracking(), page ?? 1, pageSize));
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
