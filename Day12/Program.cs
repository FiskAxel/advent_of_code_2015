using System;
using System.Collections.Generic;
using System.IO;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleInput = File.ReadAllLines("../../../input.txt");
            puzzleInput[0] = RemoveRedInArrays(puzzleInput[0]); // For part 2        

            int total = 0;
            for (int i = 0; i < puzzleInput[0].Length; i++)
            {
                string numString = "";
                int num = 0;
                while(true)
                { 
                    if (puzzleInput[0][i] == '-')
                    {
                        numString += '-';
                    }
                    else if (int.TryParse(puzzleInput[0][i].ToString(), out num))
                    {
                        numString += num;
                    }
                    else
                    {
                        break;
                    }
                    i++;
                }
                if (numString.Length != 0)
                {
                    if (numString[0] == '-')
                    {
                        total -= int.Parse(numString.Substring(1));
                    }
                    else
                    {
                        total += int.Parse(numString);
                    }
                } 
            }

            Console.WriteLine("Part 1:");
            Console.WriteLine(total);

            ////
            //// PART 2
            ////

            int nothing = 0;
            puzzleInput[0] = RemoveObjectsWithRed(puzzleInput[0], 0, out nothing);
            total = 0;
            for (int i = 0; i < puzzleInput[0].Length; i++)
            {
                string numString = "";
                int num = 0;
                while (true)
                {
                    if (puzzleInput[0][i] == '-')
                    {
                        numString += '-';
                    }
                    else if (int.TryParse(puzzleInput[0][i].ToString(), out num))
                    {
                        numString += num;
                    }
                    else
                    {
                        break;
                    }
                    i++;
                }
                if (numString.Length != 0)
                {
                    if (numString[0] == '-')
                    {
                        total -= int.Parse(numString.Substring(1));
                    }
                    else
                    {
                        total += int.Parse(numString);
                    }
                }
            }

            Console.WriteLine("Part 2:");
            Console.WriteLine(total);
        }

        static string RemoveRedInArrays(string input)
        {
            List<string> arrORobj = new List<string>();
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '[')
                {
                    arrORobj.Add("arr");
                }
                else if (input[i] == '{')
                {
                    arrORobj.Add("obj");
                }
                else if (input[i] == ']' || input[i] == '}')
                {
                    arrORobj.RemoveAt(arrORobj.Count - 1);
                }
                else if (input.Substring(i, 5) == "\"red\"" && arrORobj[arrORobj.Count - 1] == "arr")
                {
                    i += 4;
                    continue;
                }
                output += input[i];
            }
            return output;
        }
        static string RemoveObjectsWithRed(string input, int start, out int i)
        {
            string output = "";
            bool red = false;
            for (i = start; i < input.Length; i++)
            {
                if (input[i] == '{')
                {
                    output += RemoveObjectsWithRed(input, i + 1, out i);
                }
                if (input[i] == '}')
                {
                    i++;
                    break;
                }
                else if (i < input.Length - 4 && input.Substring(i, 5) == "\"red\"")
                {
                    red = true;
                }
                else if (i < input.Length )
                {
                    output += input[i];
                }
            }
            if (red)
            {
                return "";
            }
            return output;
        }
    }
}