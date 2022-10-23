using System;
using System.Linq;

namespace _02.WallDestroyer
{
    public class Program
    {
        private static int currentRow;
        private static int currentCol;
        private static char[,] wall;
        private static bool isAlive = true;
        private static int countOfHoles = 1;
        private static int countOfRods;
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            wall = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < input.Length; col++)
                {
                    wall[row, col] = input[col]; ;
                    if (wall[row, col] == 'V')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
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
                if (!isAlive)
                {
                    break;
                }

            }
            if (isAlive)
            {
                wall[currentRow, currentCol] = 'V';
                Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s).");
            }
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    Console.Write($"{wall[row, col]}");
                }
                Console.WriteLine();
            }
        }

        private static void Move(int row, int col)
        {
            if (isInside(currentRow + row, currentCol + col))
            {
                if (wall[currentRow + row, currentCol + col] == 'R')
                {
                    countOfRods++;
                    Console.WriteLine("Vanko hit a rod!");
                }
                else if (wall[currentRow + row, currentCol + col] == 'C')
                {
                    wall[currentRow, currentCol] = '*';
                    countOfHoles++;
                    currentRow += row;
                    currentCol += col;
                    wall[currentRow, currentCol] = 'E';
                    isAlive = false;
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");

                }
                else if (wall[currentRow + row, currentCol + col] =='*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{currentRow + row}, {currentCol + col}]!");
                    currentRow += row;
                    currentCol += col;
                }
                else if (wall[currentRow + row, currentCol + col] == '-')
                {
                    wall[currentRow, currentCol] = '*';
                    countOfHoles++;
                    currentRow += row;
                    currentCol += col;
                    wall[currentRow, currentCol] = '*';
                }
            }
        }

        private static bool isInside(int row, int col)
        {
            return row >= 0 && row < wall.GetLength(0) && col >= 0 && col < wall.GetLength(1);
        }
    }
}
