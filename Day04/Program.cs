using System;
using System.Security.Cryptography;
using System.Text;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            // string puzzleInput = "abcdef"; //  Test
            // string puzzleInput = "pqrstuv"; // Test
            string puzzleInput = "yzbqklnj";
            int num = 0;
            string output = "11111";
            while (output.Substring(0, 5) != "00000")
            {
                num++;
                output = CreateMD5Hash(puzzleInput + num);
            }
            Console.WriteLine("Part 1:");
            Console.WriteLine(num);

            num = 0;
            output = "111111";
            while (output.Substring(0, 6) != "000000")
            {
                num++;
                output = CreateMD5Hash(puzzleInput + num);
            }
            Console.WriteLine("Part 2:");
            Console.WriteLine(num);
        }

        static string CreateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputbytes = Encoding.ASCII.GetBytes(input);
            byte[] hashbytes = md5.ComputeHash(inputbytes);
            StringBuilder build = new StringBuilder();
            for (int i = 0; i < hashbytes.Length; i++)
            {
                build.Append(hashbytes[i].ToString("X2"));
            }

            return build.ToString(); ;
        }
    }
}
