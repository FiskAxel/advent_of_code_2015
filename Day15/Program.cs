using System;
using System.Collections.Generic;
using System.IO;

namespace Day15
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleInput = File.ReadAllLines("../../../input.txt");
            int[] rec = new int[puzzleInput.Length];
            List<int[]> recipes = new List<int[]>();
            GetAllCombinations(recipes, rec, 0);

            int highestScore = 0;
            int highestCalorieRestrictedCookieScore = 0;
            foreach (int[] recipe in recipes)
            {
                int[] dough = new int[5];
                for (int i = 0; i < puzzleInput.Length; i++)
                {
                    for (int j = 0; j < recipe[i]; j++)
                    {
                        AddTeaspoon(dough, puzzleInput[i]);
                    }
                }
                int num = 1;
                for (int i = 0; i < dough.Length - 1; i++)
                {
                    if (dough[i] <= 0)
                    {
                        num = 0;
                        break;
                    }
                    num *= dough[i];
                }
                if (num > highestScore)
                {
                    highestScore = num;
                }
                if (dough[dough.Length - 1] == 500 && num > highestCalorieRestrictedCookieScore)
                {
                    highestCalorieRestrictedCookieScore = num;
                }
            }

            Console.WriteLine("Part 1:");
            Console.WriteLine(highestScore);
            Console.WriteLine("Part 2:");
            Console.WriteLine(highestCalorieRestrictedCookieScore);
        }
        static void GetAllCombinations(List<int[]> combs, int[] recipe, int lvl)
        {
            int tot = 0;
            for (int i = 0; i < lvl; i++)
            {
                tot += recipe[i];
            }

            if (lvl == recipe.Length - 1)
            {
                recipe[lvl] = 100 - tot;
                int[] copy = new int[recipe.Length];
                for (int i = 0; i < recipe.Length; i++)
                {
                    copy[i] = recipe[i];
                }
                combs.Add(copy);
                return;
            }
            
            for (int i = 1; i < 100 - tot; i++)
            {
                recipe[lvl] = i;
                GetAllCombinations(combs, recipe, lvl + 1);
            }
        }
        static void AddTeaspoon(int[] dough, string input)
        {
            string[] parse = input.Split(' ');
            // Capacity
            if (parse[2][0] == '-')
            {
                dough[0] -= int.Parse(parse[2].Substring(1, parse[2].Length - 2));
            }
            else
            {
                dough[0] += int.Parse(parse[2].Substring(0, parse[2].Length - 1));
            }
            // Durability
            if (parse[4][0] == '-')
            {
                dough[1] -= int.Parse(parse[4].Substring(1, parse[4].Length - 2));
            }
            else
            {
                dough[1] += int.Parse(parse[4].Substring(0, parse[4].Length - 1));
            }
            // Flavor
            if (parse[6][0] == '-')
            {
                dough[2] -= int.Parse(parse[6].Substring(1, parse[6].Length - 2));
            }
            else
            {
                dough[2] += int.Parse(parse[6].Substring(0, parse[6].Length - 1));
            }
            // Texture
            if (parse[8][0] == '-')
            {
                dough[3] -= int.Parse(parse[8].Substring(1, parse[8].Length - 2));
            }
            else
            {
                dough[3] += int.Parse(parse[8].Substring(0, parse[8].Length - 1));
            }
            // Calories
            if (parse[10][0] == '-')
            {
                dough[4] -= int.Parse(parse[10].Substring(1, parse[10].Length - 1));
            }
            else
            {
                dough[4] += int.Parse(parse[10]);
            }
        }
    } 
}