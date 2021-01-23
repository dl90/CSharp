using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using week_01.Models;

namespace week_01.Controllers
{
    public class MfgController : Controller
    {
        public IActionResult Index(string message)
        {
            if (message == null)
            {
                message = "";
            }
            ViewData["Message"] = message;
            FoodStoreContext db = new FoodStoreContext();
            return View(db.Manufacturers.ToList());
        }

        // GET: Mfg/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mfg/Create
        [HttpPost]
        public IActionResult Create([Bind("Mfg,MfgDiscount")] Manufacturer manufacturer) {
            FoodStoreContext db = new FoodStoreContext();
            if (ModelState.IsValid)
            {
                db.Add(manufacturer);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mfg"] = manufacturer.Mfg;
            ViewData["MfgDiscount"] = manufacturer.MfgDiscount;
            return View(manufacturer);
        }

        // Get: Mfg/Edit
        [Route("Mfg/Edit/{mfg}")]
        public IActionResult Edit(string? mfg)
        {
            FoodStoreContext db = new FoodStoreContext();
            Manufacturer manufacturer = (from m in db.Manufacturers
                                        where m.Mfg == mfg
                                        select m).FirstOrDefault();
            return View(manufacturer);
        }

        // Post: Mfg/Edit
        [HttpPost]
        [Route("Mfg/Edit/{mfg}")]
        public IActionResult Edit([Bind("Mfg,MfgDiscount")] Manufacturer manufacturer)
        {
            ViewData["Message"] = "";
            FoodStoreContext db = new FoodStoreContext();
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(manufacturer);
                    db.SaveChanges();
                    ViewData["Message"] = "The update has been saved.";
                }
                catch (Exception ex)
                {
                    ViewData["Message"] = ex.Message;
                }
            }
            return View(manufacturer);
        }

        // DELETE: Mfg/Delete
        [Route("Mfg/Delete/{mfg}")]
        public IActionResult Delete(string? mfg)
        {
            string deleteMessage = "Manufacturer : " + mfg + " deleted successfully";
            try
            {
                FoodStoreContext db = new FoodStoreContext();
                var manufacturer = (from m in db.Manufacturers
                               where m.Mfg == mfg
                               select m).FirstOrDefault();
                db.Remove(manufacturer);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                deleteMessage = e.Message + " The product may not exist or there could be a foreign key restriction.";
            }
            return RedirectToAction("Index", "Mfg", new { message = "** " + deleteMessage });
        }
    }
}
