using System;
using System.IO;

namespace Day08
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleInput = File.ReadAllLines("../../../input.txt");
            
            int totalCode = 0;
            int totalMemory = 0;
            int extraCodePart2 = 0;
            for (int i = 0; i < puzzleInput.Length; i++)
            {
                totalCode += puzzleInput[i].Length;
                int memoryNum = puzzleInput[i].Length - 2;
                for (int j = 1; j < puzzleInput[i].Length - 1; j++)
                {
                    if (puzzleInput[i].Substring(j, 2) == "\\x")
                    {
                        memoryNum -= 3;
                        j += 3;
                    }
                    else if (puzzleInput[i][j] == '\\')
                    {
                        memoryNum -= 1;
                        j++;
                    }
                }
                totalMemory += memoryNum;

                extraCodePart2 += 4;
                for (int j = 1; j < puzzleInput[i].Length - 1; j++)
                {
                    if (puzzleInput[i][j] == '"' || puzzleInput[i][j] == '\\')
                    {
                        extraCodePart2++;
                    }
                }
            }

            Console.WriteLine("Part 1:");
            Console.WriteLine(totalCode - totalMemory);

            Console.WriteLine("Part 2:");
            Console.WriteLine(extraCodePart2);
        }
    }
}
