using System;
using System.Collections.Generic;
using System.IO;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleInput = File.ReadAllLines("../../../input.txt");

            int paperTotal = 0;
            int ribbonTotal = 0;
            for (int i = 0; i < puzzleInput.Length; i++)
            {
                string[] numbers = puzzleInput[i].Split("x");
                List<int> nums = new List<int>();   
                nums.Add(int.Parse(numbers[0]));
                nums.Add(int.Parse(numbers[1]));
                nums.Add(int.Parse(numbers[2]));
                nums.Sort();

                paperTotal += 2 * nums[0] * nums[1] 
                       + 2 * nums[1] * nums[2]
                       + 2 * nums[2] * nums[0]
                       + nums[0] * nums[1];

                ribbonTotal += nums[0] * 2 + nums[1] * 2
                             + nums[0] * nums[1] * nums[2];
            }

            Console.WriteLine("Part 1:");
            Console.WriteLine(paperTotal);
            Console.WriteLine("Part 1:");
            Console.WriteLine(ribbonTotal);
        }
    }
}
