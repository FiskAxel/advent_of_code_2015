using System;
using System.IO;

namespace Day14
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleInput = File.ReadAllLines("../../../input.txt");
            int raceTime = 2503;
            int longest = 0;
            for (int i = 0; i < puzzleInput.Length; i++)
            {
                int num = GetDistance(raceTime, puzzleInput[i]);
                if (num > longest)
                {
                    longest = num;
                }
            }
            Console.WriteLine("Part 1:");
            Console.WriteLine(longest);

            int[] scoreBoard = new int[puzzleInput.Length];
            for (int i = 0; i < raceTime; i++)
            {
                int leadLength = 0;
                for (int j = 0; j < puzzleInput.Length; j++)
                {
                    int num = GetDistance(i, puzzleInput[j]);
                    if (num > leadLength)
                    {
                        leadLength = num;
                    }
                }
                for (int j = 0; j < puzzleInput.Length; j++)
                {
                    if (GetDistance(i, puzzleInput[j]) == leadLength)
                    {
                        scoreBoard[j]++;
                    }
                }
            }
            int highestScore = 0;
            foreach (int score in scoreBoard)
            {
                if (score > highestScore)
                {
                    highestScore = score;
                }
            }
            Console.WriteLine("Part 2:");
            Console.WriteLine(highestScore);
        }

        static int GetDistance(int raceTime, string infoS)
        {
            int distance = 0;
            int time = 0;
            string[] info = infoS.Split(' ');
            while (time <= raceTime)
            {
                // FLY
                for (int i = 0; i < int.Parse(info[6]); i++)
                {
                    distance += int.Parse(info[3]);
                    if (time == raceTime)
                    {
                        break;
                    }
                    time++;
                }
                // REST
                for (int i = 0; i < int.Parse(info[13]); i++)
                {
                    time++;
                }
            }

            return distance;
        }
    }
}
