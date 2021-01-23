using System;
using System.Collections.Generic;
using System.Text;

namespace week_05
{
    class Calculator
    {
        // variable number of arguments
        public static int Add(params int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers) sum += number;
            return sum;
        }
    }
}
