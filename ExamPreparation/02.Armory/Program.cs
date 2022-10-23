using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Armory
{

    class Program
    {
        private static char[,] matrix;
        private static int currentRow;
        private static int currentCol;
        private static int gold = 0;
        private static bool isInRange = true;


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    
                    if (matrix[row, col] == 'A')
                    {
                        currentRow = row;
                        currentCol = col;
                        
                    }
                }
            }

            while (gold < 65 && isInRange)
            {
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

            if (!isInRange)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else if (gold >= 65)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {gold} gold coins.");

            for (int i = 0; i <n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }

        }
        public static void Move(int row, int col)
        {
            matrix[currentRow, currentCol] = '-';
            currentRow += row;
            currentCol += col;

            if (!IsInRange(currentRow, currentCol))
            {
                isInRange = false;
                return;
            }


            if (matrix[currentRow, currentCol] == '-')
            {
                matrix[currentRow, currentCol] = 'A';
            }
            else if (char.IsDigit(matrix[currentRow, currentCol]))
            {
                gold += int.Parse(matrix[currentRow, currentCol].ToString());
                matrix[currentRow, currentCol] = 'A';
            }
            else if (matrix[currentRow, currentCol] == 'M')
            {
                matrix[currentRow, currentCol] = '-';

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i,j] == 'M')
                        {
                            currentRow = i;
                            currentCol = j;
                        }
                    }
                }
                matrix[currentRow, currentCol] = 'A';
            }



        }
        private static bool IsInRange(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
