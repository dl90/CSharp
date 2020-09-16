using System;

namespace Week_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello \nWorld! \tTabbed");

            float num1;
            float num2;

            Console.WriteLine("First #");
            num1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Second #");
            num2 = float.Parse(Console.ReadLine());
            // Console.WriteLine($"{num1 + num2}");

            if (num1 == num2 ) {
                Console.WriteLine("same");
            } else if (num1 > num2) {
                Console.WriteLine("num1 >");
            } else {
                Console.WriteLine("num2 >");
            }

            Console.ReadKey();
        }
    }
}
