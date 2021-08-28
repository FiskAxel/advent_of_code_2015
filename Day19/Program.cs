using System;
using System.Collections.Generic;
using System.IO;

namespace Day19
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleInput = File.ReadAllLines("../../../input.txt");
            string[] replacements = new string[puzzleInput.Length - 2];
            for (int i = 0; i < puzzleInput.Length - 2; i++)
            {
                replacements[i] = puzzleInput[i];
            }
            string medMolecule = puzzleInput[puzzleInput.Length - 1];

            List<string> molecules = new List<string>();
            for (int i = 0; i < replacements.Length; i++)
            {
                string[] repSplit = replacements[i].Split(' ');
                string repIn = repSplit[0];
                string repOut = repSplit[2];
                for (int j = 0; j < medMolecule.Length - (repIn.Length - 1); j++)
                {
                    if (medMolecule.Substring(j, repIn.Length) == repIn)
                    {
                        string newMolecule = "";
                        for (int k = 0; k < medMolecule.Length; k++)
                        {
                            if (k == j)
                            {
                                newMolecule += repOut;
                                k += (repIn.Length - 1);
                            }
                            else
                            {
                                newMolecule += medMolecule[k];
                            }
                        }
                        if (!molecules.Contains(newMolecule))
                        {
                            molecules.Add(newMolecule);
                        }
                    }
                }
            }
            Console.WriteLine("Part 1:");
            Console.WriteLine(molecules.Count);

            ////
            //// PART 2
            ////

            int atoms = 0;
            for (int i = 0; i < medMolecule.Length; i++)
            {
                if ((int)medMolecule[i] <= 90)
                {
                    atoms++;
                }
            }
            int steps = atoms - 1; // - 1  for e
            for (int i = 0; i < medMolecule.Length; i++)
            {
                if (medMolecule[i] == 'Y')
                {
                    steps -= 2;
                }
                else if (i < medMolecule.Length - 1)
                {
                    string subm = medMolecule.Substring(i, 2);
                    if (subm == "Ar") // || "Rn"
                    {
                        steps -= 2;
                    }
                }
            }
            Console.WriteLine("Part 2:");
            Console.WriteLine(steps);
        }
    }
}