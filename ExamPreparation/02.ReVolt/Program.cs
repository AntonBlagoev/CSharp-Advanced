using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ReVolt
{
    class Program
    {
        private static char[,] matrix;
        private static int playerRow;
        private static int playerCol;
        private static bool isFinish;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                    if (matrix[i, j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }
            matrix[playerRow, playerCol] = '-';

            for (int i = 0; i < countOfCommands; i++)
            {
                if (isFinish)
                {
                    break;
                }
                string command = Console.ReadLine();

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

            matrix[playerRow, playerCol] = 'f';

            if (isFinish)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void Move(int row, int col)
        {

            if (!IsInRange(playerRow + row, playerCol + col))
            {
                GoToOtherSide(row, col);
            }

            else if (matrix[playerRow + row, playerCol + col] == 'F')
            {
                playerRow += row;
                playerCol += col;
                isFinish = true;
                return;
            }
            else if (matrix[playerRow + row, playerCol + col] == 'B')
            {
                playerRow += row * 2;
                playerCol += col * 2;
                if (!IsInRange(playerRow, playerCol))
                {
                    GoToOtherSide(row, col);
                }
            }
            else if (matrix[playerRow + row, playerCol + col] == 'T')
            {
                return;
            }
            else
            {
                playerRow += row;
                playerCol += col;
            }
        }

        private static void GoToOtherSide(int row, int col)
        {
            if (row < 0)
            {
                playerRow = matrix.GetLength(0) - 1;
            }
            else if (row > 0)
            {
                playerRow = 0;
            }
            else if (col < 0)
            {
                playerCol = matrix.GetLength(1) - 1;
            }
            else if (col > 0)
            {
                playerCol = 0;
            }
        }

        private static bool IsInRange(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
