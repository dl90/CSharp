using assignment_1.Data;
using assignment_1.Repositories;
using assignment_1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace assignment_1.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ClientBankAccountRepo _clientBankAccountRepo;

        public AccountsController(ApplicationDbContext context)
        {
            _context = context;
            _clientBankAccountRepo = new ClientBankAccountRepo(_context);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index(string type)
        {
            var accountsByType = _clientBankAccountRepo.GetByType(type);
            return View(accountsByType);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Details(int clientID, int accountNum)
        {
            var accountDetails = _clientBankAccountRepo.GetOne(clientID, accountNum);
            return View(accountDetails);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int clientID, int accountNum)
        {
            var accountDetails = _clientBankAccountRepo.GetOne(clientID, accountNum);
            return View(accountDetails);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(ClientBankAccountDetailsVM account)
        {
            if (ModelState.IsValid)
            {
                bool success = _clientBankAccountRepo.Update(account);
                if (!success) return View(account);
            }

            try
            {
                return RedirectToAction("Details", "Accounts", account);
            }
            catch
            {
                return View(account);
            }
        }

        public IActionResult Profile()
        {
            var userName = User.Identity.Name;
            var accountDetails = _clientBankAccountRepo.GetFirstByEmail(userName);
            return View(accountDetails);
        }
    }
}
