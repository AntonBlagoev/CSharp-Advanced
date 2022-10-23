using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.RallyRacing
{
    class Program
    {
        private static char[,] matrix;
        private static int kilometers = 0;
        private static int currRow = 0;
        private static int currCol = 0;
        private static bool isFinish = false;


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();

            matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine().Replace(" ", "");
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End" && !isFinish)
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

            matrix[currRow, currCol] = 'C';

            if (isFinish)
            {
                Console.WriteLine($"Racing car {racingNumber} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }
            Console.WriteLine($"Distance covered {kilometers} km.");

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
            matrix[currRow, currCol] = '.';
            currRow += row;
            currCol += col;

            if (matrix[currRow, currCol] == 'F')
            {
                matrix[currRow, currCol] = '.';
                kilometers += 10;
                isFinish = true;
                return;
            }
            else if (matrix[currRow, currCol] == 'T')
            {
                matrix[currRow, currCol] = '.';
                kilometers += 30;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == 'T')
                        {
                            currRow = i;
                            currCol = j;
                            matrix[currRow, currCol] = '.';
                            return;
                        }
                    }
                }
            }
            else
            {
                matrix[currRow, currCol] = '.';
                kilometers += 10;
            }
        }
    }
}
