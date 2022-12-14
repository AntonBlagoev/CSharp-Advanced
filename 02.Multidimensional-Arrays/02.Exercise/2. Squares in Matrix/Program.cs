using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            char[,] matrix = new char[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] inputChars = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => char.Parse(n))
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputChars[col];
                }
            }

            int equalCharsCount = 0;

            if (matrix.GetLength(0) > 0 && matrix.GetLength(1) > 0)
            {
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                    {
                        if (matrix[row, col] == matrix[row, col + 1] 
                            && matrix[row, col + 1] == matrix[row + 1, col] 
                            && matrix[row + 1, col] == matrix[row + 1, col + 1])
                        {
                            equalCharsCount++;
                        }
                    }
                }
            }
            Console.WriteLine(equalCharsCount);
        }
    }
}
