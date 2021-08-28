using System;
using System.Collections.Generic;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            string puzzleInput = "1113122113";
            char[] input = puzzleInput.ToCharArray();

            input = LookSay(input, 40);
            Console.WriteLine("Part 1:");
            Console.WriteLine(input.Length);

            input = LookSay(input, 10);
            Console.WriteLine("Part 2:");
            Console.WriteLine(input.Length);
        }

        static char[] LookSay(char[] input, int loopSize)
        {
            for (int i = 0; i < loopSize; i++)
            {
                List<char> newSequence = new List<char>();
                int numOfDigits = 1;
                for (int j = 0; j < input.Length; j++)
                { 
                    if (j == input.Length - 1 || input[j] != input[j + 1])
                    {
                        newSequence.Add(numOfDigits.ToString()[0]);
                        newSequence.Add(input[j]);
                        numOfDigits = 1;
                    }
                    else
                    {
                        numOfDigits++;
                    }
                }
                input = new char[newSequence.Count];
                newSequence.CopyTo(input);          
            }
            return input;
        }
    }
}