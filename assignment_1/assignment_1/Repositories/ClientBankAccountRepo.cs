using assignment_1.Data;
using assignment_1.Models;
using assignment_1.ViewModels;
using System.Linq;

namespace assignment_1.Repositories
{
    public class ClientBankAccountRepo
    {
        private readonly ApplicationDbContext _context;

        public ClientBankAccountRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        private IQueryable<ClientBankAccountDetailsVM> GetAll()
        {
            var BaCa = from ba in _context.BankAccounts
                       from ca in _context.ClientAccounts
                       .Where(ca => ca.AccountNum == ba.AccountNum).DefaultIfEmpty()
                       select new
                       {
                           ba.AccountNum,
                           ba.AccountType,
                           ba.Balance,
                           ca.ClientID
                       };


            var all = from baca in BaCa
                      from c in _context.Clients
                      .Where(c => c.ClientID == baca.ClientID).DefaultIfEmpty()
                      select new ClientBankAccountDetailsVM
                      {
                          AccountNum = baca.AccountNum,
                          AccountType = baca.AccountType,

                          ClientID = c.ClientID,
                          LastName = c.LastName ?? "",
                          FirstName = c.FirstName ?? "",
                          Email = c.Email ?? "",
                          Balance = baca.Balance
                      };

            return all;
        }

        public IQueryable<ClientBankAccountListVM> GetByType(string type)
        {
            var all = GetAll();
            var res = from a in all
                      orderby a.LastName, a.FirstName
                      select new ClientBankAccountListVM
                      {
                          AccountNum = a.AccountNum,
                          AccountType = a.AccountType,
                          ClientID = a.ClientID,
                          LastName = a.LastName,
                          FirstName = a.FirstName
                      };

            return type == "All"
                ? res
                : res.Where(cba => cba.AccountType == type);
        }

        public ClientBankAccountDetailsVM GetOne(int clientID, int accountNum)
        {
            var all = GetAll();
            return all.Where(cba => cba.ClientID == clientID && cba.AccountNum == accountNum).FirstOrDefault();
        }

        public bool Update(ClientBankAccountDetailsVM account)
        {
            var clientRepo = new ClientRepo(_context);
            bool clientSuccess = clientRepo.Update(account.ClientID, account.FirstName, account.LastName);

            var bankAccountRepo = new BankAccountRepo(_context);
            bool bankAccountSuccess = bankAccountRepo.Update(account.AccountNum, account.Balance);

            return clientSuccess && bankAccountSuccess;
        }

        public ClientBankAccountDetailsVM Create(string accountType, decimal balance, string firstName, string lastName, string email)
        {
            // @TODO handle partial creation
            var clientRepo = new ClientRepo(_context);
            var client = clientRepo.Create(email, firstName, lastName);

            var bankAccountRepo = new BankAccountRepo(_context);
            var bankAccount = bankAccountRepo.Create(accountType, balance);

            if (client == null || bankAccount == null) return null;

            var clientBankAccount = new ClientAccount() { AccountNum = bankAccount.AccountNum, ClientID = client.ClientID };
            _context.ClientAccounts.Add(clientBankAccount);
            _context.SaveChanges();

            return GetOne(clientBankAccount.ClientID, clientBankAccount.AccountNum);
        }

        public ClientBankAccountDetailsVM GetFirstByEmail(string email)
        {
            var all = GetAll();
            return all.Where(cba => cba.Email == email).FirstOrDefault();
        }
    }
}
