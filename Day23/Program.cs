using System;
using System.IO;

namespace Day23
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleInput = File.ReadAllLines("../../../input.txt");

            int b = Reader(0, 0, puzzleInput);
            Console.WriteLine("Part 1:");
            Console.WriteLine(b);

            b = Reader(1, 0, puzzleInput);
            Console.WriteLine("Part 1:");
            Console.WriteLine(b);
        }
        
        static int Reader(int a, int b, string[] puzzleInput)
        { 
            for (int i = 0; i < puzzleInput.Length; i++)
            {
                string[] split = puzzleInput[i].Split();
                if (split[0] == "hlf")
                {
                    if (split[1] == "a") { a /= 2; }
                    if (split[1] == "b") { b /= 2; }
                }
                else if (split[0] == "tpl")
                {
                    if (split[1] == "a") { a *= 3; }
                    if (split[1] == "b") { b *= 3; }
                }
                else if (split[0] == "inc")
                {
                    if (split[1] == "a") { a++; }
                    if (split[1] == "b") { b++; }
                }
                else if (split[0] == "jmp")
                {
                    char ope = split[1][0];
                    int num = int.Parse(split[1].Substring(1, split[1].Length - 1));
                    if (ope == '+') { i += num - 1; }
                    if (ope == '-') { i -= num + 1; }
                }
                else if (split[0] == "jie")
                {
                    char ope = split[2][0];
                    int num = int.Parse(split[2].Substring(1, split[2].Length - 1));
                    if (split[1][0] == 'a' && a % 2 == 0 ||
                        split[1][0] == 'b' && b % 2 == 0)
                    {
                        if (ope == '+') { i += num - 1; }
                        if (ope == '-') { i -= num + 1; }
                    }
                }
                else if (split[0] == "jio")
                {
                    char ope = split[2][0];
                    int num = int.Parse(split[2].Substring(1, split[2].Length - 1));
                    if (split[1][0] == 'a' && a == 1 ||
                        split[1][0] == 'b' && b == 1)
                    {
                        if (ope == '+') { i += num - 1; }
                        if (ope == '-') { i -= num + 1; }
                    }
                }
            }
            return b;
        }
    }
}
