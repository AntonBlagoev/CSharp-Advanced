using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[rows][];

            for (int row = 0; row < rows; row++)
            {
                pascalTriangle[row] = new long[row + 1];
                pascalTriangle[row][0] = 1;
                pascalTriangle[row][pascalTriangle[row].Length - 1] = 1;

                if (row > 1)
                {
                    for (int col = 1; col < pascalTriangle[row].Length - 1; col++)
                    {
                        pascalTriangle[row][col] = pascalTriangle[row - 1][col - 1] + pascalTriangle[row - 1][col];
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(" ", pascalTriangle[i]));
            }
        }
    }
}
