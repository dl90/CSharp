using System;

namespace week_06_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            int acc1Num = bank.AddSavingsAccount(200m, 0.03m);
            int acc2Num = bank.AddCheckingAccount(300m, 2.95m);

            SavingsAccount sa1 = (SavingsAccount)bank.GetAccount(acc1Num);
            CheckingAccount ca1 = (CheckingAccount)bank.GetAccount(acc2Num);

            Console.WriteLine(sa1.Balance);
            sa1.Credit(2000m);
            Console.WriteLine(sa1.CalculateInterest());

            ca1.Debit(-1m);
            ca1.Debit(300m);
            ca1.Credit(1m);
            ca1.Credit(300m);

            var x = (SavingsAccount)bank.GetAccount(acc1Num);
            var y = (CheckingAccount)bank.GetAccount(acc2Num);

            Console.WriteLine(x.Balance);
            Console.WriteLine(y.Balance);
        }
    }
}
