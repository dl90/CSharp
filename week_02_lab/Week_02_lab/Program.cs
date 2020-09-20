using System;

namespace Week2_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Table x = new Table();
            x.Print();

            Console.Write("\n");
            new Counter(5);
            Console.ReadKey();
        }


    }
}
