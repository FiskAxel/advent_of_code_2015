using System;
using System.IO;
using System.Collections.Generic;

namespace Day17
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleInput = File.ReadAllLines("../../../input.txt");
            int litersOfEggnogg = 150;

            List<string> combinations = new List<string>();
            AllPossible(puzzleInput, combinations);

            int result = 0;
            List<string> combsForPart2 = new List<string>();
            foreach (string comb in combinations)
            {
                int sum = 0;
                string[] split = comb.Split(',');
                for (int i = 0; i < split.Length - 1; i++)
                {
                    sum += int.Parse(split[i]);
                    if (sum > litersOfEggnogg)
                    {     
                        break;
                    }
                }
                if (sum == litersOfEggnogg)
                {
                    combsForPart2.Add(comb);
                    result++;
                }
            }
            Console.WriteLine("Part 1:");
            Console.WriteLine(result);

            int shortest = int.MaxValue;
            for (int i = 0; i < combsForPart2.Count; i++)
            {
                if (combsForPart2[i].Length < shortest)
                {
                    shortest = combsForPart2[i].Length;
                }
            }
            result = 0;
            for (int i = 0; i < combsForPart2.Count; i++)
            {
                if (combsForPart2[i].Length == shortest)
                {
                    result++;
                }
            }
            Console.WriteLine("Part 2:");
            Console.WriteLine(result);
        }

        static void AllPossible(string[] input, List<string> combs)
        {
            double len = Math.Pow(2, input.Length) - 1;
            for (int i = 1; i < len; i++)
            {
                string str = Convert.ToString(i, 2).PadLeft(input.Length);
                string output = "";
                for (int j = 0; j < input.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        output += input[j] + ',';
                    }
                }
                combs.Add(output);
            }
        }
    }
}