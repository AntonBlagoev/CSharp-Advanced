using System;
using System.Collections.Generic;

namespace _02.PawnWars
{
    class Program
    {
        private static char[,] matrix = new char[8, 8];
        private static int whiteRow;
        private static int whiteCol;
        private static int blackRow;
        private static int blackCol;

        static void Main(string[] args)
        {
            for (int row = 0; row < 8; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < 8; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                    else if (matrix[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            while (true)
            {
                if (whiteRow == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {GetCoordinates(whiteRow, whiteCol)}.");
                    return;
                }
                else if (blackRow == 7)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {GetCoordinates(blackRow, blackCol)}.");
                    return;
                }

                if (IsCaptured("White"))
                {
                    return;
                }
                matrix[whiteRow, whiteCol] = '-';
                whiteRow--;
               
                if (IsCaptured("Black"))
                {
                    return;
                }
                matrix[blackRow, blackCol] = '-';
                blackRow++;
            }
        }

        private static bool IsCaptured(string color)
        {
            if (whiteRow == blackRow + 1)
            {
                if (whiteCol == blackCol + 1 || whiteCol == blackCol - 1)
                {
                    if (color == "White")
                    {
                        whiteRow = blackRow;
                        whiteCol = blackCol;
                    }
                    else
                    {
                        blackRow = whiteRow;
                        blackCol = whiteCol;
                    }
                   
                    Console.WriteLine($"Game over! {color} capture on {GetCoordinates(whiteRow, whiteCol)}.");
                    return true;
                }
            }
            return false;
        }

        private static string GetCoordinates(int row, int col)
        {
            string[] cols = { "a", "b", "c", "d", "e", "f", "g", "h" };
            int[] rows = { 8, 7, 6, 5, 4, 3, 2, 1 };

            return $"{cols[col]}{rows[row]}";
        }
    }
}
