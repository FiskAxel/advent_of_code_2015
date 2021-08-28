using System;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            string puzzleInput = "cqjxjnds";
            char[] password = puzzleInput.ToCharArray();

            while(!ValidPassword(password))
            {
                password = IncrementPassword(password, password.Length - 1);
            }
            Console.WriteLine("Part 1:");
            Console.WriteLine(password);

            password = IncrementPassword(password, password.Length - 1);
            while (!ValidPassword(password))
            {
                password = IncrementPassword(password, password.Length - 1);
            }
            Console.WriteLine("Part 2:");
            Console.WriteLine(password);
        }
        static char[] IncrementPassword(char[] input, int index)
        {
            int asciiCode = input[index];
            asciiCode++;
            if (asciiCode > 122)
            {
                asciiCode = 97;
                if (index > 0)
                {
                    input = IncrementPassword(input, index - 1);
                }
            }
            input[index] = (char)asciiCode;
            return input;
        }
        static bool ValidPassword(char[] input)
        {  
            bool increasingStraight = false;
            for (int i = 0; i < input.Length - 2; i++)
            {
                int one = input[i];
                int two = input[i + 1];
                int three = input[i + 2];
                if (one + 1 == two && two + 1 == three)
                {
                    increasingStraight = true;
                    break;
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'i' || input[i] == 'o' || input[i] == 'l')
                {
                    return false;
                }
            }

            bool twoPairs = false;
            char first = ' ';
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input [i + 1])
                {
                    if (first != ' ' && input[i] != first)
                    {
                        twoPairs = true;
                        break;
                    }
                    first = input[i];
                    i++;
                }
            }

            if (increasingStraight && twoPairs)
            {
                return true;
            }
            return false;
        }
    }
}
