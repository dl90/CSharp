using System;

namespace Week2_lab
{
    class Counter
    {

        int[] nums;
        int neg;
        int pos;
        int zeros;

        public Counter(int arg)
        {
            nums = new int[arg];
            Query(arg);
            Print();
        }


        public void Query(int count)
        {
            for(int i = 0; i < count; i++)
            {
                Console.Write($"{i + 1}th Number: ");
                nums[i] = Int32.Parse(Console.ReadLine().Trim());
                Console.Write("\n");
            }
        }

        public void Print()
        {
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0) {
                    pos++;
                } else if(nums[i] < 0) {
                    neg++;
                } else {
                    zeros++;
                }
            }

            Console.WriteLine($"Negatives: {neg} | Zeros: {zeros} | Positive: {pos}");
        }
    }
}
