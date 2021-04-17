using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using week_11_preclass_azure.Data;
using week_11_preclass_azure.Models;
using week_11_preclass_azure.ViewModels;

namespace week_11_preclass_azure.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            // This query performs an inner join between
            // the Produce and bridge table.
            var query1 = from p in _context.Produces
                         from ps in _context.ProduceSuppliers
                         where p.ProduceID == ps.ProduceID
                         select new
                         {
                             ProduceID = p.ProduceID,
                             ProduceName = p.Description,
                             SupplierID = ps.SupplierID,
                             Quantity = ps.Qty
                         };

            // This next query performs an inner join between 
            // the first query and the Suppliers table. It 
            // is often easier to break the queries up into multiple steps
            // so two queries are used for this case instead one big messy query.

            // You will want to convert this query to a specific type
            // by adjusting the select clause, for example;
            //             select new yourVM() {};
            // I recommend creating a VM which has the exact same attributes as the query.
            var query2 = from q in query1
                         from s in _context.Suppliers
                         where q.SupplierID == s.SupplierID
                         select new ProduceSupplierJoinedVM()
                         {
                             ProduceID = q.ProduceID,
                             ProduceName = q.ProduceName,
                             SupplierID = q.SupplierID,
                             Quantity = q.Quantity,
                             SupplierName = s.SupplierName
                         };

            return View(query2); // Return the query results to the view.
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
