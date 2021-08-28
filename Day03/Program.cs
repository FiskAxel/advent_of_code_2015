using System;
using System.IO;
using System.Collections.Generic;

namespace Day03
{
    struct Coordinate
    {
        public int X;
        public int Y;
        
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleInput = File.ReadAllLines("../../../input.txt");

            List<Coordinate> deliveries = new List<Coordinate>();
            Coordinate santaLocation = new Coordinate(0, 0);
            deliveries.Add(santaLocation);

            for (int i = 0; i < puzzleInput[0].Length; i++)
            {
                santaLocation = UpdateLocation(santaLocation, puzzleInput[0][i]);
                if (!deliveries.Contains(santaLocation))
                {
                    deliveries.Add(santaLocation);
                }
            }

            Console.WriteLine("Part 1:");
            Console.WriteLine(deliveries.Count);

            ////
            //// NEXT YEAR
            ////

            santaLocation = new Coordinate(0, 0);
            Coordinate roboSantaLocation = new Coordinate(0, 0);
            deliveries.Clear();
            deliveries.Add(santaLocation);

            for (int i = 0; i < puzzleInput[0].Length; i++)
            {
                if (i % 2 == 0)
                {
                    santaLocation = UpdateLocation(santaLocation, puzzleInput[0][i]);
                    if (!deliveries.Contains(santaLocation))
                    {
                        deliveries.Add(santaLocation);
                    }
                }
                else
                {
                    roboSantaLocation = UpdateLocation(roboSantaLocation, puzzleInput[0][i]);
                    if (!deliveries.Contains(roboSantaLocation))
                    {
                        deliveries.Add(roboSantaLocation);
                    }
                }
            }

            Console.WriteLine("Part 2:");
            Console.WriteLine(deliveries.Count);
        }

        static Coordinate UpdateLocation(Coordinate location, int direction)
        {
            if (direction == '<')
            {
                location.X--;
            }
            else if (direction == '>')
            {
                location.X++;
            }
            else if (direction == 'v')
            {
                location.Y--;
            }
            else if (direction == '^')
            {
                location.Y++;
            }

            return location;
        }
    }
}
