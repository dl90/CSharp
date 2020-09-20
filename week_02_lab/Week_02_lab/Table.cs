using System;

namespace Week2_lab
{
    class Table
    {
        public void Print()
        {
            Console.WriteLine("number\tsquare\tcube");
            for (int i = 0; i <= 10; i++)
            {
                Console.Write($"{i}\t");
                Console.Write($"{Square(i)}\t");
                Console.Write($"{Cube(i)}\n");
            }
        }

        private int Square(int arg)
        {
            return arg * arg;
        }

        private int Cube(int arg)
        {
            return arg * arg * arg;
        }
    }
}
