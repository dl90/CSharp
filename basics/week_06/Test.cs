using System;
using System.Collections.Generic;
using System.Text;

namespace week_06
{
    class Test
    {
        public Test()
        {
            Console.WriteLine("default");
        }

        public Test(string arg) :this()
        {
            Console.WriteLine(arg);
        }
    }
}
