using System;
using System.IO;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("../../../input.txt");

            ////
            //// PART 1
            ////
            
            int niceStrings = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (VowelCount(input[i]) < 3)
                {
                    continue;
                }
                if (!ContainsDouble(input[i]))
                {
                    continue;
                }
                if (ContainsBad(input[i]))
                {
                    continue;
                }
                niceStrings++;
            }
            Console.WriteLine("Part 1:");
            Console.WriteLine(niceStrings);

            ////
            //// PART 2
            //// 

            niceStrings = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (!ContainsPair(input[i]))
                {
                    continue;
                }
                if (!ContainsRepeat(input[i]))
                {
                    continue;
                }
                niceStrings++;
            }
            Console.WriteLine("Part 2:");
            Console.WriteLine(niceStrings);
        }

        static int VowelCount(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' ||
                    input[i] == 'e' ||
                    input[i] == 'i' ||
                    input[i] == 'o' ||
                    input[i] == 'u')
                {
                    count++;
                }
            }
            return count;
        }
        static bool ContainsDouble(string input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1])
                {
                    return true;
                }
            }
            return false;
        }
        static bool ContainsBad(string input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input.Substring(i, 2) == "ab" ||
                    input.Substring(i, 2) == "cd" ||
                    input.Substring(i, 2) == "pq" ||
                    input.Substring(i, 2) == "xy")
                {
                    return true;
                }
            }
            return false;
        }

        static bool ContainsPair(string input)
        {
            for (int i = 0; i < input.Length - 3; i++)
            {
                string pair = input.Substring(i, 2);
                for (int j = i + 2; j < input.Length - 1; j++)
                {
                    string pair2 = input.Substring(j, 2);
                    if (pair == pair2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static bool ContainsRepeat(string input)
        {
            for (int i = 2; i < input.Length; i++)
            {
                if (input[i - 2] == input[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
