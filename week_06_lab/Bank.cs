
using System.Collections.Generic;

namespace week_06_lab
{
    class Bank
    {
        private Dictionary<int, Account> accounts;
        private int pk = 1;
        public Bank ()
        {
            accounts = new Dictionary<int, Account>();
        }

        public int AddCheckingAccount(decimal initialBalance, decimal fee)
        {
            CheckingAccount acc = new CheckingAccount(initialBalance, fee);
            accounts.Add(pk++, acc);
            return pk - 1;
        }

        public int AddSavingsAccount(decimal initialBalance, decimal interestRate)
        {
            SavingsAccount acc = new SavingsAccount(initialBalance, interestRate);
            accounts.Add(pk++, acc);
            return pk - 1;
        }

        public Account GetAccount(int primaryKey)
        {
            Account acc;
            accounts.TryGetValue(primaryKey, out acc);
            return acc;
        }
    }
}
