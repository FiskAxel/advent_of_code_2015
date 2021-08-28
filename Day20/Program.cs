using System;

namespace Day20
{
    class Program
    {
        static void Main(string[] args)
        {
            string puzzleInput = "29000000";

            int num = 0;
            int i = 0;
            while (num < int.Parse(puzzleInput))
            {
                i++;
                num = PresentsForHouseNum(i);  
            }
            Console.WriteLine("Part 1:");
            Console.WriteLine(i);
           
            num = 0;
            i = 0;
            while (num < int.Parse(puzzleInput))
            {
                i++;
                num = PFHNum2(i);
            }
            Console.WriteLine("Part 2:");
            Console.WriteLine(i);
        }

        static int PresentsForHouseNum(int num)
        {
            int output = 0;
            for (int i = 1; i < Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    output += i * 10;
                    output += (num / i) * 10;
                }
            }
            return output;
        }

        static int PFHNum2(int num)
        {
            int output = 0;
            for (int i = 1; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    if (num / i <= 50)
                    {
                        output += i * 11;
                    }
                    if (num / (num / i) <= 50)
                    {
                        output += (num / i) * 11;
                    }        
                }
            }
            return output;
        }
    }
}
