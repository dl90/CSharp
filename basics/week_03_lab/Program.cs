using System;

namespace week_03_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var def = new Classlist();
            var UI = new UI();
            UI.run(def);

            Console.ReadKey();
        }

    }
}
