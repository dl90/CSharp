using System;

namespace week_06
{
    class Rectangle: Shape, ITestable
    {
        public Rectangle()
        {
            // Console.WriteLine("Rectangle constructor");
        }

        public override void Draw()
        {
            Console.WriteLine("Draw Rectangle");
        }

        internal void RectangleMethod()
        {
            Console.WriteLine("Rectangle Method");
        }

        public void Test()
        {
            Console.WriteLine("Rectable Test");
        }
    }
}
