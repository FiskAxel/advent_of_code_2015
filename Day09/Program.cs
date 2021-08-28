using System;
using System.Collections.Generic;
using System.IO;

namespace Day09
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleInput = File.ReadAllLines("../../../input.txt");

            List<string> locations = new List<string>();
            List<string[]> distances = new List<string[]>();
            for (int i = 0; i < puzzleInput.Length; i++)
            {
                string[] parse = puzzleInput[i].Split(' ');
                if (!locations.Contains(parse[0]))
                {
                    locations.Add(parse[0]);
                }
                if (!locations.Contains(parse[2]))
                {
                    locations.Add(parse[2]);
                }
                string[] dist = new string[3];
                dist[0] = parse[0];
                dist[1] = parse[2];
                dist[2] = parse[4];
                distances.Add(dist);
            }

            List<string[]> routes = new List<string[]>();
            string[] route = new string[locations.Count];
            GetPermutations(route, 0, locations, routes);
            int shortestDistance = int.MaxValue;
            int longestDistance = 0;
            for (int i = 0; i < routes.Count; i++)
            {
                int dis = GetTotalDistance(distances, routes[i]);
                if (dis < shortestDistance)
                {
                    shortestDistance = dis;
                }
                if (dis > longestDistance)
                {
                    longestDistance = dis;
                }
            }
            Console.WriteLine("Part 1:");
            Console.WriteLine(shortestDistance);
            Console.WriteLine("Part 2:");
            Console.WriteLine(longestDistance);          
        } 
        static void GetPermutations(string[] route, int index, List<string> locs, List<string[]> routes)
        {

            for (int i = 0; i < locs.Count; i++)
            {
                route[index] = locs[i];
                if (locs.Count != 1)
                {
                    List<string> remainingLocs = new List<string>();
                    for (int j = 0; j < locs.Count; j++)
                    {
                        if (j != i)
                        {
                            remainingLocs.Add(locs[j]);
                        }
                    }
                    GetPermutations(route, index + 1, remainingLocs, routes);
                }
                else
                {
                    string[] temp = new string[route.Length];
                    for (int j = 0; j < route.Length; j++)
                    {
                        temp[j] = route[j];
                    }
                    routes.Add(temp);
                }
            }
        }
        static int GetTotalDistance(List<string[]> distances, string[] route)
        {
            int output = 0;
            for (int i = 0; i < route.Length - 1; i++)
            {
                output += GetDistanceBetween(distances, route[i], route[i + 1]);
            }
            return output;
        }
        static int GetDistanceBetween(List<string[]> distance, string location, string destination)
        {
            for (int k = 0; k < distance.Count; k++)
            {
                if (distance[k][0] == location && distance[k][1] == destination ||
                    distance[k][1] == location && distance[k][0] == destination)
                {
                    return int.Parse(distance[k][2]);
                }
            }
            return 0;
        }
    }
}