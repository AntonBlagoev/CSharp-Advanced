using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BeaverAtWork
{
    class Program
    {
        private static int beaverRow;
        private static int beaverCol;
        private static char[,] matrix;

        private static List<char> branches = new List<char>();
        private static int totalBranches = 0;


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine().Replace(" ", "");
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }
                    else if (char.IsLower(matrix[row, col]))
                    {
                        totalBranches++;
                    }
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end" && totalBranches != 0)
            {
                if (command == "up")
                {
                    Move(-1, 0);
                }
                else if (command == "down")
                {
                    Move(1, 0);
                }
                else if (command == "left")
                {
                    Move(0, -1);
                }
                else if (command == "right")
                {
                    Move(0, 1);
                }
            }

            if (totalBranches == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {totalBranches} branches left.");
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
        private static void Move(int row, int col)
        {
            if (!isInRange(beaverRow + row, beaverCol + col))
            {
                if (branches.Any())
                {
                    branches.Remove(branches[branches.Count - 1]);
                }
                return;
            }
            matrix[beaverRow, beaverCol] = '-';
            beaverRow += row;
            beaverCol += col;

            if (char.IsLower(matrix[beaverRow, beaverCol]))
            {
                branches.Add(matrix[beaverRow, beaverCol]);
                totalBranches--;
                matrix[beaverRow, beaverCol] = 'B';
            }
            else if (matrix[beaverRow, beaverCol] == 'F')
            {
                matrix[beaverRow, beaverCol] = '-';

                if (row != 0) // Up or Down
                {
                    if (beaverRow == 0)
                    {
                        beaverRow = matrix.GetLength(1) - 1;
                    }
                    else if (beaverRow == matrix.GetLength(1) - 1)
                    {
                        beaverRow = 0;
                    }
                }
                else if(col != 0) // Left or Right
                {
                    if (beaverCol == 0)
                    {
                        beaverCol = matrix.GetLength(0) - 1;
                    }
                    else if (beaverCol == matrix.GetLength(0) - 1)
                    {
                        beaverCol = 0;
                    }
                }
                if (char.IsLower(matrix[beaverRow, beaverCol]))
                {
                    branches.Add(matrix[beaverRow, beaverCol]);
                    totalBranches--;
                }

                matrix[beaverRow, beaverCol] = 'B';
            }
            else
            {
                matrix[beaverRow, beaverCol] = 'B';
            }
        }
        private static bool isInRange(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
