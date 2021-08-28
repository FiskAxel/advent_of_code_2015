using System;
using System.IO;

namespace Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("../../../input.txt");
   
            string turnOn = "turn on ";
            string turnOff = "turn off ";
            string toggle = "toggle ";
            string through = " through ";

            ////
            //// PART 1
            ////

            bool[,] grid = new bool[1000, 1000];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].StartsWith(turnOn))
                {
                    string[] xyStart = input[i].Substring(turnOn.Length, input[i].IndexOf(through) - turnOn.Length).Split(",");
                    string[] xyLen = input[i].Substring(input[i].IndexOf(through) + through.Length).Split(",");
                    grid = TurnOn(grid, int.Parse(xyStart[0]), int.Parse(xyStart[1]), int.Parse(xyLen[0]), int.Parse(xyLen[1]));
                }
                else if (input[i].StartsWith(turnOff))
                {
                    string[] xyStart = input[i].Substring(turnOff.Length, input[i].IndexOf(through) - turnOff.Length).Split(",");
                    string[] xyLen = input[i].Substring(input[i].IndexOf(through) + through.Length).Split(",");
                    grid = TurnOff(grid, int.Parse(xyStart[0]), int.Parse(xyStart[1]), int.Parse(xyLen[0]), int.Parse(xyLen[1]));
                }
                else if (input[i].StartsWith(toggle))
                {
                    string[] xyStart = input[i].Substring(toggle.Length, input[i].IndexOf(through) - toggle.Length).Split(",");
                    string[] xyLen = input[i].Substring(input[i].IndexOf(through) + through.Length).Split(",");
                    grid = Toggle(grid, int.Parse(xyStart[0]), int.Parse(xyStart[1]), int.Parse(xyLen[0]), int.Parse(xyLen[1]));
                }
            }

            int lightsLit = 0;
            for (int y = 0; y < 1000; y++)
            {
                for (int x = 0; x < 1000; x++)
                {
                    if (grid[y, x])
                    {
                        lightsLit++;
                    }
                }
            }

            Console.WriteLine("Part 1:");
            Console.WriteLine(lightsLit);

            ////
            //// PART 2
            ////

            int[,] grid2 = new int[1000, 1000];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].StartsWith(turnOn))
                {
                    string[] xyStart = input[i].Substring(turnOn.Length, input[i].IndexOf(through) - turnOn.Length).Split(",");
                    string[] xyLen = input[i].Substring(input[i].IndexOf(through) + through.Length).Split(",");
                    grid2 = TurnOn2(grid2, int.Parse(xyStart[0]), int.Parse(xyStart[1]), int.Parse(xyLen[0]), int.Parse(xyLen[1]));
                }
                else if (input[i].StartsWith(turnOff))
                {
                    string[] xyStart = input[i].Substring(turnOff.Length, input[i].IndexOf(through) - turnOff.Length).Split(",");
                    string[] xyLen = input[i].Substring(input[i].IndexOf(through) + through.Length).Split(",");
                    grid2 = TurnOff2(grid2, int.Parse(xyStart[0]), int.Parse(xyStart[1]), int.Parse(xyLen[0]), int.Parse(xyLen[1]));
                }
                else if (input[i].StartsWith(toggle))
                {
                    string[] xyStart = input[i].Substring(toggle.Length, input[i].IndexOf(through) - toggle.Length).Split(",");
                    string[] xyLen = input[i].Substring(input[i].IndexOf(through) + through.Length).Split(",");
                    grid2 = TurnOn2(grid2, int.Parse(xyStart[0]), int.Parse(xyStart[1]), int.Parse(xyLen[0]), int.Parse(xyLen[1]));
                    grid2 = TurnOn2(grid2, int.Parse(xyStart[0]), int.Parse(xyStart[1]), int.Parse(xyLen[0]), int.Parse(xyLen[1]));
                }
            }

            int totalBrightness = 0;
            for (int y = 0; y < 1000; y++)
            {
                for (int x = 0; x < 1000; x++)
                {
                    totalBrightness += grid2[y, x];
                }
            }

            Console.WriteLine("Part 2:");
            Console.WriteLine(totalBrightness);
        }

        static bool[,] TurnOn(bool[,] grid, int yStart, int xStart, int yLen, int xLen)
        {
            for (int y = yStart; y <= yLen; y++)
            {
                for (int x = xStart; x <= xLen; x++)
                {
                    grid[y, x] = true;
                }
            }

            return grid;
        }
        static bool[,] TurnOff(bool[,] grid, int yStart, int xStart, int yLen, int xLen)
        {
            for (int y = yStart; y <= yLen; y++)
            {
                for (int x = xStart; x <= xLen; x++)
                {
                    grid[y, x] = false;
                }
            }

            return grid;
        }
        static bool[,] Toggle(bool[,] grid, int yStart, int xStart, int yLen, int xLen)
        {
            for (int y = yStart; y <= yLen; y++)
            {
                for (int x = xStart; x <= xLen; x++)
                {
                    if (grid[y, x])
                    {
                        grid[y, x] = false;
                    }
                    else
                    {
                        grid[y, x] = true;
                    }
                }
            }

            return grid;
        }

        static int[,] TurnOn2(int[,] grid, int yStart, int xStart, int yLen, int xLen)
        {
            for (int y = yStart; y <= yLen; y++)
            {
                for (int x = xStart; x <= xLen; x++)
                {
                    grid[y, x] += 1;
                }
            }

            return grid;
        }
        static int[,] TurnOff2(int[,] grid, int yStart, int xStart, int yLen, int xLen)
        {
            for (int y = yStart; y <= yLen; y++)
            {
                for (int x = xStart; x <= xLen; x++)
                {
                    if (grid[y, x] > 0)
                    {
                        grid[y, x] -= 1;
                    }    
                }
            }

            return grid;
        }
    }
}
