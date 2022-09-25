using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] inputRows = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputRows[col];
                }
            }

            int biggestSum = 0;
            int biggestRow = 0;
            int biggestCol = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (sum > biggestSum)
                    {
                        biggestSum = sum;
                        biggestRow = row;
                        biggestCol = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[biggestRow, biggestCol]} {matrix[biggestRow, biggestCol + 1]}");
            Console.WriteLine($"{matrix[biggestRow + 1, biggestCol]} {matrix[biggestRow + 1, biggestCol + 1]}");
            Console.WriteLine(biggestSum);
        }
    }
}
