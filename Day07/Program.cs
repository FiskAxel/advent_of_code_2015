using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day07
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleInput = File.ReadAllLines("../../../input.txt");

            ////
            //// PART 1
            ////

            Dictionary<string, int> wires = new Dictionary<string, int>();
            Dictionary<string, string> wireInstructions = new Dictionary<string, string>();
            for (int i = 0; i < puzzleInput.Length; i++)
            {
                string[] parse = puzzleInput[i].Split(" -> ");
                int num = 0;
                if (int.TryParse(parse[0], out num))
                {
                    wires.Add(parse[1], num);
                }
                else
                {
                    wireInstructions.Add(parse[1], parse[0]);
                }
            }

            while (wireInstructions.Count > 0)
            {
                for (int i = 0; i < wireInstructions.Count; i++)
                {
                    string[] inst = wireInstructions.ElementAt(i).Value.Split(' ');
                    string key = wireInstructions.ElementAt(i).Key;
                    int a = 0;
                    int b = 0;
                    if (inst.Length == 1 && wires.TryGetValue(inst[0], out a))
                    {
                        wires.Add(key, a);
                        wireInstructions.Remove(key);
                    }
                    else if (inst[0] == "NOT")
                    {
                        if (wires.TryGetValue(inst[1], out a))
                        {
                            wires.Add(key, NOT(a));
                            wireInstructions.Remove(key);
                        } 
                    }
                    else if (wires.TryGetValue(inst[0], out a) && wires.TryGetValue(inst[2], out b) ||
                            int.TryParse(inst[0], out a) && wires.TryGetValue(inst[2], out b) ||
                            wires.TryGetValue(inst[0], out a) && int.TryParse(inst[2], out b))
                    {
                        if (inst[1] == "AND")
                        {
                            wires.Add(key, AND(a, b));
                        }
                        else if (inst[1] == "OR")
                        {
                            wires.Add(key, OR(a, b));
                        }
                        else if (inst[1] == "LSHIFT")
                        {
                            wires.Add(key, LS(a, b));
                        }
                        else if (inst[1] == "RSHIFT")
                        {
                            wires.Add(key, RS(a, b));
                        }
                        wireInstructions.Remove(key);
                    }                    
                }
            }

            int aWireSignal = wires["a"];
            Console.WriteLine("Part 1:");
            Console.WriteLine(aWireSignal);

            ////
            //// PART 2
            ////

            wires = new Dictionary<string, int>();
            wireInstructions = new Dictionary<string, string>();
            for (int i = 0; i < puzzleInput.Length; i++)
            {
                string[] parse = puzzleInput[i].Split(" -> ");
                int num = 0;
                if (int.TryParse(parse[0], out num))
                {
                    wires.Add(parse[1], num);
                }
                else
                {
                    wireInstructions.Add(parse[1], parse[0]);
                }
            }
            wires["b"] = aWireSignal;

            while (wireInstructions.Count > 0)
            {
                for (int i = 0; i < wireInstructions.Count; i++)
                {
                    string[] inst = wireInstructions.ElementAt(i).Value.Split(' ');
                    string key = wireInstructions.ElementAt(i).Key;
                    int a = 0;
                    int b = 0;
                    if (inst.Length == 1 && wires.TryGetValue(inst[0], out a))
                    {
                        wires.Add(key, a);
                        wireInstructions.Remove(key);
                    }
                    else if (inst[0] == "NOT")
                    {
                        if (wires.TryGetValue(inst[1], out a))
                        {
                            wires.Add(key, NOT(a));
                            wireInstructions.Remove(key);
                        }
                    }
                    else if (wires.TryGetValue(inst[0], out a) && wires.TryGetValue(inst[2], out b) ||
                            int.TryParse(inst[0], out a) && wires.TryGetValue(inst[2], out b) ||
                            wires.TryGetValue(inst[0], out a) && int.TryParse(inst[2], out b))
                    {
                        if (inst[1] == "AND")
                        {
                            wires.Add(key, AND(a, b));
                        }
                        else if (inst[1] == "OR")
                        {
                            wires.Add(key, OR(a, b));
                        }
                        else if (inst[1] == "LSHIFT")
                        {
                            wires.Add(key, LS(a, b));
                        }
                        else if (inst[1] == "RSHIFT")
                        {
                            wires.Add(key, RS(a, b));
                        }
                        wireInstructions.Remove(key);
                    }
                }
            }

            aWireSignal = wires["a"];
            Console.WriteLine("Part 1:");
            Console.WriteLine(aWireSignal);
        }

        static int NOT(int a)
        {
            string num = ToBinary(a);
            string output = "";
            for (int i = 0; i < 16; i++)
            {
                if (num[i] == '1')
                {
                    output += '0';
                }
                else
                {
                    output += '1';
                }
            }
            return ToDecimal(output);
        }
        static int AND(int a, int b)
        {
            string num1 = ToBinary(a);
            string num2 = ToBinary(b);
            string output = "";
            for (int i = 0; i < 16; i++)
            {
                if (num1[i] == '1' && num2[i] == '1')
                {
                    output += '1';
                }
                else
                {
                    output += '0';
                }
            }
            return ToDecimal(output);
        }
        static int OR(int a, int b)
        {
            string num1 = ToBinary(a);
            string num2 = ToBinary(b);
            string output = "";
            for (int i = 0; i < 16; i++)
            {
                if (num1[i] == '1' || num2[i] == '1')
                {
                    output += '1';
                }
                else
                {
                    output += '0';
                }
            }
            return ToDecimal(output);
        }

        static int RS(int a, int shift)
        {
            string num = ToBinary(a);
            string output = "";
            for (int i = 0; i < 16 - shift; i++)
            {
                output += num[i + shift];
            }
            return ToDecimal(output);
        }
        static int LS(int a, int shift)
        {
            string num = ToBinary(a);
            string output = "";
            for (int i = 0; i < shift; i++)
            {
                output += '0';
            }
            for (int i = 0; i < 16 - shift; i++)
            {
                output += num[i];
            }
            return ToDecimal(output);
        }

        // LSB at index 0
        static string ToBinary(int input)
        {
            string output = "";
            for (int i = 0; i < 16; i++)
            {
                double pow = i + 1;
                if (input % Math.Pow(2, pow) > 0)
                {
                    output += '1';
                }
                else
                {
                    output += '0';
                }
                int iValue = Convert.ToInt32(Math.Pow(2, pow - 1));
                input -= int.Parse(output.Substring(i, 1)) * iValue;
            }            
            return output;
        }
        static int ToDecimal(string input)
        {
            int output = 0;
            for (int i = 0; i < input.Length; i++)
            {
                double pow = i;
                int iValue = Convert.ToInt32(Math.Pow(2, pow));
                output += int.Parse(input.Substring(i, 1)) * iValue;
            }
            return output;
        }
    }
}
