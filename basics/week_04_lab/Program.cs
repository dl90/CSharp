using System;

namespace week_04_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            UI();
            Console.ReadKey();
        }

        static bool PerfectNumber(int input)
        {
            var total = 0;
            for(int i = 1; i < input; i++)
            {
                if (input % i == 0 && total <= input) total += i;
            }
            return total == input;
        }

        static int GreatestCommonDivisor(int x, int y)
        {
            var min = Math.Min(x, y);
            var GCD = 1;
            for(int i = 2; i < min; i++)
            {
                if(x % i == 0 && y % i == 0)
                {
                    GCD = Math.Max(i, GCD);
                }
            }
            return GCD;
        }

        static bool IsPrime(int input)
        {
            for(int divisor = 2; divisor * divisor <= input; divisor++)
            {
                if (input % divisor == 0) return false;
                else continue;
            }
            return true;
        }

        static void UI()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("1: Check number for perfect number");
            Console.WriteLine("2: Find the GDC for two numbers");
            Console.WriteLine("3: Check numer for prime");
            Console.WriteLine("-1: Exit");
            Console.WriteLine("----------------------------");

            int option;
            do
            {
                Console.Write("\nOption: ");
                option = Parse(Console.ReadLine().Trim());

                switch (option)
                {
                    case 1:
                        Console.Write("\nPerfect number arg: ");
                        int num = Parse(Console.ReadLine().Trim());
                        Console.WriteLine($"PerfectNumber({num}) = {PerfectNumber(num)}");
                        break;

                    case 2:
                        Console.Write("\nGDC first arg: ");
                        int a = Parse(Console.ReadLine().Trim());
                        Console.Write("GDC second arg: ");
                        int b = Parse(Console.ReadLine().Trim());
                        Console.WriteLine($"GCD({a}, {b}) = {GreatestCommonDivisor(a, b)}");
                        break;

                    case 3:
                        Console.Write("Prime arg: ");
                        int x = Parse(Console.ReadLine().Trim());
                        Console.WriteLine($"IsPrime({x}) = {IsPrime(x)}");
                        break;
                }
            } while (option > 0);
            Console.WriteLine("Bye");
        }

        static int Parse(string arg)
        {
            int num;
            bool success;
            do
            {
                success = int.TryParse(arg, out num);
                if (!success)
                {
                    Console.Write("Incorrect input, again: ");
                    arg = Console.ReadLine().Trim();
                }
            } while (!success);
            return num;
        }
    }
}
