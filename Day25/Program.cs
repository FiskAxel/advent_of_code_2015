using System;

namespace Day25
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = NumberNumAt(3083, 2978);
            long code = 20151125;
            for (int i = 0; i < num - 1; i++)
            {
                code = (code * 252533) % 33554393;
            }
            Console.WriteLine("Part 1:");
            Console.WriteLine(code);
        }

        static long NumberNumAt(int col, int row)
        {
            long colVal = 0;
            for (int i = 0; i < col; i++)
            {
                colVal += i + 1;
            }
            long rowVal = colVal;
            for (int i = 0; i < row - 1; i++)
            {
                rowVal += col + i;
            }
            return rowVal;
        }
    }
}