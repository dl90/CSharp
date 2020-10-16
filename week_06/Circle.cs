using System;

namespace week_06
{
    class Circle: Shape, ITestable, IPrintable
    {
        public Circle ()
        {
            // Console.WriteLine("Circle constructor");
        }

        public override void Draw()
        {
            Console.WriteLine("Draw Circle");
        }

        internal void CircleMethod()
        {
            Console.WriteLine("Circle Method");
        }

        public void Test()
        {
            Console.WriteLine("Circle Test");
        }

        public void Print()
        {
            Console.WriteLine("Circle Print");
        }
    }
}
