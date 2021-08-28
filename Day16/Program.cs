using System;
using System.IO;

namespace Day16
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleInput = File.ReadAllLines("../../../input.txt");
            string[] outputMFCSAM = File.ReadAllLines("../../../mfcsam.txt");

            int sueNum = 0;
            for (int i = 0; i < puzzleInput.Length; i++)
            {
                string parse1 = puzzleInput[i].Substring(puzzleInput[i].IndexOf(": ") + 2);
                string[] parse = parse1.Split(", ");
                int matches = 0;
                for (int j = 0; j < parse.Length; j++)
                {
                    for (int k = 0; k < outputMFCSAM.Length; k++)
                    {
                        if (parse[j] == outputMFCSAM[k])
                        {
                            matches++;
                            break;
                        }
                    }
                }
                if (matches == parse.Length)
                {
                    sueNum = i + 1;
                    break;
                }
            }
            Console.WriteLine("Part 1:");
            Console.WriteLine(sueNum);

            ////
            //// PART 2
            ////

            int realSueNum = 0;
            for (int i = 0; i < puzzleInput.Length; i++)
            {
                string parse1 = puzzleInput[i].Substring(puzzleInput[i].IndexOf(": ") + 2);
                string[] parse = parse1.Split(", ");
                int matches = 0;
                for (int j = 0; j < parse.Length; j++)
                {
                    for (int k = 0; k < outputMFCSAM.Length; k++)
                    {
                        string[] parse2 = parse[j].Split(": ");
                        string[] parseMFCSAM = outputMFCSAM[k].Split(": ");
                        if (parse2[0] == "cats" || parse[0] == "trees")
                        {
                            if (parseMFCSAM[0] == parse2[0] && int.Parse(parse2[1]) > int.Parse(parseMFCSAM[1]))
                            {
                                matches++;
                                break;
                            }
                            continue;
                        }
                        else if (parse2[0] == "pomeranians" || parse2[0] == "goldfish")
                        {
                            if (parseMFCSAM[0] == parse2[0] && int.Parse(parse2[1]) < int.Parse(parseMFCSAM[1]))
                            {
                                matches++;
                                break;
                            }
                            continue;
                        }
                        if (parse[j] == outputMFCSAM[k])
                        {
                            matches++;
                            break;
                        }
                    }
                }
                if (matches == parse.Length)
                {
                    realSueNum = i + 1;
                    break;
                }
            }
            Console.WriteLine("Part 2:");
            Console.WriteLine(realSueNum);
        }
    }
}