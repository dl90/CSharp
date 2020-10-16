
namespace week_06
{
    class Program
    {
        static void Main(string[] args)
        {

            Circle circle1 = new Circle();
            Rectangle rectangle1 = new Rectangle();

            Poly(circle1);
            Poly(rectangle1);

            Test(circle1);
            Test(rectangle1);
        }

        static void Poly(Shape shape)
        {
            // polymorphic method || dymaic overloading
            // method called depends on the object passed at runtime
            shape.Draw();

            // not SOLID
            // open closed principle
            Circle x = shape as Circle;
            if (x != null) x.CircleMethod();

            Rectangle y = shape as Rectangle;
            if (y != null) y.RectangleMethod();

            if (shape is Circle)
            {
                var circ = (Circle)shape;
                circ.CircleMethod();
            }

            if (shape is Rectangle)
            {
                var rect = (Rectangle)shape;
                rect.RectangleMethod();
            }
        }

        static void Test(ITestable arg)
        {
            arg.Test();
        }

        static void Print(IPrintable arg)
        {
            arg.Print();
        }
    }
}
