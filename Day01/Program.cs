using System;
using System.IO;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleInput = File.ReadAllLines("../../../input.txt");

            int floor = 0;
            bool found = false;
            int firstBasement = 1;
            for (int i = 0; i < puzzleInput[0].Length; i++)
            {
                if (puzzleInput[0][i] == '(')
                {
                    floor++;
                }
                else
                {
                    floor--;
                }
                if (!found && floor == -1)
                {
                    firstBasement += i;
                    found = true;
                }
            }

            Console.WriteLine("Part 1:");
            Console.WriteLine(floor);
            Console.WriteLine("Part 2:");
            Console.WriteLine(firstBasement);
        }
    }
}
