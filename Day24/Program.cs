using System;
using System.Collections.Generic;
using System.IO;

namespace Day24
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleInput = File.ReadAllLines("../../../input.txt");
            int totWeight = 0;
            for (int i = 0; i < puzzleInput.Length; i++)
            {
                totWeight += int.Parse(puzzleInput[i]);
            }
            Console.WriteLine("Part 1:");
            Console.WriteLine(BestWay(puzzleInput, totWeight / 3));
            Console.WriteLine("Part 2:");
            Console.WriteLine(BestWay(puzzleInput, totWeight / 4));
            // Part 1 - 1:16
            // Part 2 - 1:17
            // Both Part 1 & 2 - 2:36
        }
        
        static long BestWay(string[] input, int weight)
        {
            List<string> groupings = new List<string>();
            int shortest = input.Length / 3;
            int len = Convert.ToInt32(Math.Pow(2, input.Length));
            for (int i = 1; i < len; i++)
            {
                string bin = Convert.ToString(i, 2).PadLeft(input.Length, '0');
                string group = "";
                int count = 0;
                for (int j = 0; j < input.Length; j++)
                {
                    if (bin[j] == '1')
                    {
                        count++;
                    }
                }
                if (count > shortest)
                {
                    continue;
                }

                for (int j = 0; j < input.Length; j++)
                {
                    if (bin[j] == '1')
                    {
                        group += input[j] + ' ';
                    }
                }

                if (GroupWeight(group) == weight)
                {
                    int length = GroupLength(group);
                    if (length < shortest)
                    {
                        shortest = length;
                        groupings = new List<string>();
                        groupings.Add(group.Trim());
                    }
                    else if (length == shortest)
                    {
                        groupings.Add(group);
                    }
                }
            }

            long best = long.MaxValue;
            foreach (string group in groupings)
            {
                long GQE = GroupQuantumEnganglement(group);
                if (GQE < best)
                {
                    best = GQE;
                }
            }
            return best;
        }

        static int GroupWeight(string input)
        {
            int output = 0;
            string[] split = input.Trim().Split(' ');
            for (int i = 0; i < split.Length; i++)
            {
                output += int.Parse(split[i]);
            }
            return output;
        }
        static int GroupLength(string input)
        {
            return input.Trim().Split(' ').Length;
        }
        static long GroupQuantumEnganglement(string input)
        {
            long output = 1;
            string[] split = input.Trim().Split(' ');
            for (int i = 0; i < split.Length; i++)
            {
                output *= long.Parse(split[i]);
            }
            return output;
        }
    }
}