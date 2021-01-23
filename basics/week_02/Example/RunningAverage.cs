using System;

namespace Examples
{
    class RunningAverage
    {
        private float total = 0f;
        private int count = 0;

        public void Run()
        {
            Console.Write("Enter nums to average, any negative number to exit: ");
            float input = Parse();

            while (input > 0)
            {
                total += input;
                count++;

                Console.Write("Enter next grade: ");
                input = Parse();
            }

            // :F rounded to nearest hundredth
            string res = Average(total, count) >= 0f ? $"Avg: {Average(total, count):F}" : "No input provided";
            Console.WriteLine($"{res} Total: {total} Count: {count}");
        }

        private float Parse()
        {
            float input = 0f;

            while (input == 0f && input <= 0f)
            {
                try
                {
                    input = float.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return input;
        }

        private float Average(float total, int count)
        {
            if (count > 0)
            {
                // implicit conversion, count promoted to type float
                return total / count;
            }
            else
            {
                return -1f;
            }
        }
    }
}
