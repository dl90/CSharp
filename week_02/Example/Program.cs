using System;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            // default constructor, not useable when constructor is defined
            // Account user = new Account();

            //Account user1 = new Account("User_1", 1.1m);
            //Account user2 = new Account("User_2", -1.1m);

            //DisplayAccount(user1);
            //DisplayAccount(user2);

            //decimal parse = 0;
            //while(parse == 0) 
            //{
            //    Console.Write($"\n{user1.Name} deposit: ");
            //    try
            //    {
            //        parse = decimal.Parse(Console.ReadLine());
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //    user1.Deposit(parse);
            //}

            //Console.WriteLine();
            //DisplayAccount(user1);
            //DisplayAccount(user2);


            //Student student1 = new Student("Student_1", 88);
            //Student student2 = new Student("Studnet_2", 91);

            //Console.WriteLine();
            //Console.WriteLine($"{student1.Average} {student1.Grade()}");
            //Console.WriteLine($"{student2.Average} {student2.Grade()}");

            //Average average = new Average(5);
            //average.Query();
            //Console.WriteLine(average.GetAverage());

            RunningAverage avg = new RunningAverage();
            avg.Run();

            Console.ReadKey();
        }

        private static void DisplayAccount(Account user)
        {
            // format specifier :C = currency
            Console.WriteLine($"{user.Name}, {user.Balance:C}");
        }
    }
}
