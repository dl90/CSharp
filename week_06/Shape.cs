using System;

namespace week_06
{
    abstract class Shape
    {
        public Shape()
        {
            Console.WriteLine("Shape constructor");
        }

        public Shape(string arg): this()
        {
            Console.WriteLine($"{arg}");
        }

        public abstract void Draw();
    }
}
