using System;

namespace week_06_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            int acc1Num = bank.AddSavingsAccount(200m, 0.03m);
            int acc2Num = bank.AddCheckingAccount(300m, 2m);

            SavingsAccount sa1 = (SavingsAccount)bank.GetAccount(acc1Num);
            CheckingAccount ca1 = (CheckingAccount)bank.GetAccount(acc2Num);

            Console.WriteLine(sa1.Balance);
            sa1.Credit(2000m);
            ca1.Debit(300m);

            Console.WriteLine(sa1.CalculateInterest());
            ca1.Credit(200m);

            sa1 = null;
            ca1 = null;

            sa1 = (SavingsAccount)bank.GetAccount(acc1Num);
            ca1 = (CheckingAccount)bank.GetAccount(acc2Num);

            Console.WriteLine(sa1.Balance);
            Console.WriteLine(ca1.Balance);
        }
    }
}
