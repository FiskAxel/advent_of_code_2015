using System;
using System.Collections.Generic;
using System.IO;

namespace Day13
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleInput = File.ReadAllLines("../../../input.txt");
            List<string> guests = new List<string>();
            Dictionary<string, int> netValues = new Dictionary<string, int>();
            for (int i = 0; i < puzzleInput.Length; i++)
            {
                string[] parse = puzzleInput[i].Split(' ');
                if (!guests.Contains(parse[0]))
                {
                    guests.Add(parse[0]);
                }
                
                int num = 0;
                if (parse[2] == "gain")
                {
                    num = int.Parse(parse[3]);
                }
                else
                {
                    num = int.Parse(parse[3]) * -1;
                }
                string name2 = parse[10].Substring(0, parse[10].Length - 1);
                if (!netValues.ContainsKey(parse[0] + name2))
                {
                    netValues.Add(parse[0] + name2, num);
                    netValues.Add(name2 + parse[0], num);
                    
                    // part 2
                    if (!netValues.ContainsKey(parse[0] + "Me"))
                    {
                        netValues.Add(parse[0] + "Me", 0);
                        netValues.Add("Me" + parse[0], 0);
                    }
                    if (!netValues.ContainsKey(name2 + "Me"))
                    {
                        netValues.Add(name2 + "Me", 0);
                        netValues.Add("Me" + name2[0], 0);
                    } 
                }
                else
                {
                    netValues[parse[0] + name2] += num;
                    netValues[name2 + parse[0]] += num;
                }
            }

            string[] arrangement = new string[guests.Count];
            arrangement[0] = guests[0];
            guests.RemoveAt(0);
            List<string[]> combinations = new List<string[]>();
            GetEveryCombination(combinations, guests, 1, arrangement);
            int happiness = 0;
            for (int i = 0; i < combinations.Count; i++)
            {
                int num = 0;
                for (int j = 0; j < combinations[i].Length; j++)
                {
                    num += netValues[combinations[i][j] + combinations[i][(j + 1) % combinations[i].Length]];
                }
                if (num > happiness)
                {
                    happiness = num;
                }
            }

            Console.WriteLine("Part 1:");
            Console.WriteLine(happiness);

            guests.Add(arrangement[0]);
            combinations = new List<string[]>();
            GetEveryCombination(combinations, guests, 0, arrangement);
            happiness = 0;
            for (int i = 0; i < combinations.Count; i++)
            {
                int num = 0;
                for (int j = 0; j < combinations[i].Length - 1; j++)
                {
                    num += netValues[combinations[i][j] + combinations[i][(j + 1)]];
                }
                if (num > happiness)
                {
                    happiness = num;
                }
            }

            Console.WriteLine("Part 1:");
            Console.WriteLine(happiness);
        }
        static void GetEveryCombination(List<string[]> every, List<string> guests, int index, string[] arrengment)
        {
            for (int i = 0; i < guests.Count; i++)
            {
                arrengment[index] = guests[i];
                if (guests.Count != 1)
                {
                    List<string> shortened = new List<string>();
                    for (int j = 0; j < guests.Count; j++)
                    {
                        if (j != i)
                        {
                            shortened.Add(guests[j]);
                        }
                    }
                    GetEveryCombination(every, shortened, index + 1, arrengment);
                }
                else
                {
                    string[] add = new string[arrengment.Length];
                    for (int j = 0; j < add.Length; j++)
                    {
                        add[j] = arrengment[j];
                    }
                    every.Add(add);
                }
            }
        }
    }
}