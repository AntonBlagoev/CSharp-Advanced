using System;
using System.Linq;


namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int maxSum = int.MinValue;
            int maxRowIndex = 0;
            int maxColIndex = 0;

            if (matrix.GetLength(0) > 2 && matrix.GetLength(1) > 2)
            {
                for (int row = 0; row < matrix.GetLength(0) - 2; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                    {
                        int currSum = 
                            matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + 
                            matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + 
                            matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                        if (currSum > maxSum)
                        {
                            maxSum = currSum;
                            maxRowIndex = row;
                            maxColIndex = col;
                        }
                    }
                }
                Console.WriteLine($"Sum = {maxSum}");
                for (int row = maxRowIndex; row < maxRowIndex + 3; row++)
                {
                    for (int col = maxColIndex; col < maxColIndex + 3; col++)
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
