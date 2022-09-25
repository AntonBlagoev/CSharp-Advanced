using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                int[] cols = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = cols[col];
                }
            }

            int sumLeftDiagonals = 0;
            int sumRightDiagonals = 0;

            for (int i = 0, j = matrixSize - 1; i < matrixSize; i++, j--)
            {
                sumLeftDiagonals += matrix[i, i];
                sumRightDiagonals += matrix[i, j];
            }

            //for (int row = 0; row < matrixSize; row++)
            //{
            //    for (int col = 0; col < matrixSize; col++)
            //    {
            //        if (col == row)
            //        {
            //            sumLeftDiagonals += matrix[row, col];
            //        }
            //        if (col == (matrixSize - 1) - row)
            //        {
            //            sumRightDiagonals += matrix[row, col];
            //        }
            //    }
            //}
            Console.WriteLine(Math.Abs(sumLeftDiagonals - sumRightDiagonals));
        }
    }
}
