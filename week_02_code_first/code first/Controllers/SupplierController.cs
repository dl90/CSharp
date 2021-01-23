using code_first.ContextHelpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_first.Controllers
{
    public class SupplierController : Controller
    {
        private MyDbContext _context;

        public SupplierController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Suppliers);
        }
    }
}
