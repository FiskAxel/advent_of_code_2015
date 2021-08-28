using System;
using System.IO;

namespace Day18
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleInput = File.ReadAllLines("../../../input.txt");
            bool[,] lights = new bool[puzzleInput.Length, puzzleInput.Length];
            for (int y = 0; y < puzzleInput.Length; y++)
            {
                for (int x = 0; x < puzzleInput.Length; x++)
                {
                    if (puzzleInput[y][x] == '#')
                    {
                        lights[y, x] = true;
                    }
                }
            }

            int result = 0;
            for (int i = 0; i < 100; i++)
            {
                bool[,] nextLights = new bool[100, 100];
                for (int y = 0; y < 100; y++)
                {
                    for (int x = 0; x < 100; x++)
                    {
                        int num = CountAdjecents(lights, y, x);
                        if (num == 3 || lights[y, x] && num == 2)
                        {
                            nextLights[y, x] = true;
                        }
                    }
                }
                result = 0;
                for (int y = 0; y < 100; y++)
                {
                    for (int x = 0; x < 100; x++)
                    {
                        lights[y, x] = nextLights[y, x];
                        if (lights[y, x])
                        {
                            result++;
                        }
                    }
                }
            }

            Console.WriteLine("Part 1:");
            Console.WriteLine(result);

            ////
            //// PART 2
            ////

            lights = new bool[puzzleInput.Length, puzzleInput.Length];
            for (int y = 0; y < puzzleInput.Length; y++)
            {
                for (int x = 0; x < puzzleInput.Length; x++)
                {
                    if (y == 0 && x == 0 || y == 99 && x == 0 ||
                        y == 0 && x == 99 || y == 99 && x == 99)
                    {
                        lights[y, x] = true;
                    }
                    else if (puzzleInput[y][x] == '#')
                    {
                        lights[y, x] = true;
                    }
                }
            }

            result = 0;
            for (int i = 0; i < 100; i++)
            {
                bool[,] nextLights = new bool[100, 100];
                for (int y = 0; y < 100; y++)
                {
                    for (int x = 0; x < 100; x++)
                    {
                        int num = CountAdjecents(lights, y, x);
                        if (y == 0 && x == 0 || y == 99 && x == 0 ||
                            y == 0 && x == 99 || y == 99 && x == 99)
                        {
                            nextLights[y, x] = true;
                        }
                        
                        else if (num == 3 || lights[y, x] && num == 2)
                        {
                            nextLights[y, x] = true;
                        }
                        else
                        {
                            nextLights[y, x] = false;
                        }
                    }
                }
                result = 0;
                for (int y = 0; y < 100; y++)
                {
                    for (int x = 0; x < 100; x++)
                    {
                        lights[y, x] = nextLights[y, x];
                        if (nextLights[y, x])
                        {
                            result++;
                        }
                    }
                }
            }

            Console.WriteLine("Part 2:");
            Console.WriteLine(result);
        }
        static int CountAdjecents(bool[,] lights, int y, int x)
        {
            int output = 0;
            if (y > 0 && x > 0 && lights[y - 1, x - 1] == true)
            {
                output++;
            }
            if (y > 0 && lights[y - 1, x] == true)
            {
                output++;
            }
            if (y > 0 && x < 99 && lights[y - 1, x + 1] == true)
            {
                output++;
            }

            if (x > 0 && lights[y, x - 1] == true)
            {
                output++;
            }
            if (x < 99 && lights[y, x + 1] == true)
            {
                output++;
            }

            if (y < 99 && x > 0 && lights[y + 1, x - 1] == true)
            {
                output++;
            }
            if (y < 99 && lights[y + 1, x] == true)
            {
                output++;
            }
            if (y < 99 && x < 99 && lights[y + 1, x + 1] == true)
            {
                output++;
            }
            return output;
        }
    }
}