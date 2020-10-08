using System;

namespace week_05
{
    class Program
    {
        static void Main(string[] args)
        {
            // memory allocated for the object on the heap
            Person p1 = new Person();
            p1.Name = "John";
            p1.Introduce("Jane");

            Person p2 = Person.getPerson("John II");
            p2.Introduce("Jane II");

            Person p3 = new Person("John III");
            p3.Introduce("Jane III");

            // specific to C#, initialized object with specific field
            Person p4 = new Person { Name = "Jeff" };
            p4.Introduce("Josh");

            Point point1 = new Point(1, 1);
            point1.Move(2, 2);

            try
            {
                point1.Move(null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(Calculator.Add(new int[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine(Calculator.Add(1, 2, 3, 4, 5));

            int tryparseNum;
            bool result = int.TryParse("1a1", out tryparseNum);

            int x = 1;
            // passing by value
            // method1(x);
            Console.WriteLine(x); // x == 1

            // passing by reference
            // argument refers to the object directly
            method1(ref x);

            // inheritance
            Presentation pres1 = new Presentation();
            PresentationText presText1 = new PresentationText();

        }

        private static void method1(ref int x)
        {
            x = 5;
        }
    }
}
