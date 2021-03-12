using assignment_1.Data;
using assignment_1.Models;
using System.Linq;

namespace assignment_1.Repositories
{
    public class BankAccountRepo
    {
        private readonly ApplicationDbContext _context;

        public BankAccountRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public BankAccount FindOne(int accountNum)
        {
            return _context.BankAccounts
                .Where(b => b.AccountNum == accountNum)
                .FirstOrDefault();
        }

        public bool Update(int accountNum, decimal balance)
        {
            BankAccount account = FindOne(accountNum);
            if (account == null || balance < 0) return false;

            account.Balance = balance;
            _context.SaveChanges();
            return true;
        }

        public BankAccount Create(string accountType, decimal initialBalance)
        {
            if (accountType.Trim().Length < 1 || initialBalance < 0) return null;

            var account = new BankAccount { AccountType = accountType, Balance = initialBalance };
            _context.BankAccounts.Add(account);
            _context.SaveChanges();
            return account;
        }
    }
}
