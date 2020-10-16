using System;

namespace Examples
{
    class Average
    {
        private int[] entries;
        
        public Average(int size)
        {
            entries = new int[size];
        }

        public void Query()
        {
            for(int i = 0; i < entries.Length; i++)
            {
                Console.Write($"Enter {i}th grade: ");
                int num = 0;

                while(num == 0)
                {
                    try
                    {
                        num = Int32.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                entries[i] = num;
            }
        }

        public float GetAverage()
        {
            int sum = 0;
            foreach(int entry in entries) {
                sum += entry;
            }

            float _sum = sum;
            float _len = entries.Length;
            return _sum / _len;
        }
    }
}
