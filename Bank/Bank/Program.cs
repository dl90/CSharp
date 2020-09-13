using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            // default constructor, not useable when constructor is defined
            // Account user = new Account();
            Account user1 = new Account("User_1", 1.1m);
            Account user2 = new Account("User_2", -1.1m);

            DisplayAccount(user1);
            DisplayAccount(user2);

            Console.Write($"{user1.Name} deposit: ");
            user1.Deposit(decimal.Parse(Console.ReadLine()));

            DisplayAccount(user1);
            DisplayAccount(user2);
        }

        static void DisplayAccount(Account user)
        {
            // format specifier :C = currency
            Console.WriteLine($"{user.Name}, {user.Balance:C}");
        }
    }
}
