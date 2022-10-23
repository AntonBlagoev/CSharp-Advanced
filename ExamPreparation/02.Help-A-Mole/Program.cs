using System;

namespace _02.Help_A_Mole
{
    class Program
    {
        private static char[,] playingField;
        private static int points;
        private static int currentRow;
        private static int currentCol;


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            playingField = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    playingField[row, col] = input[col];
                    if (playingField[row, col] == 'M')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End" && points < 25)
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

            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }
            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                for (int col = 0; col < playingField.GetLength(1); col++)
                {
                    Console.Write($"{playingField[row, col]}");
                }
                Console.WriteLine();
            }


        }

        private static void Move(int row, int col)
        {
            if (isInRange(currentRow + row, currentCol + col))
            {
                if (playingField[currentRow + row, currentCol + col] == '-')
                {
                    playingField[currentRow, currentCol] = '-';
                    currentRow += row;
                    currentCol += col;
                    playingField[currentRow, currentCol] = 'M';
                }

                else if (char.IsDigit(playingField[currentRow + row, currentCol + col]))
                {
                    points += int.Parse(playingField[currentRow + row, currentCol + col].ToString());
                    playingField[currentRow, currentCol] = '-';
                    currentRow += row;
                    currentCol += col;
                    playingField[currentRow, currentCol] = 'M';
                }

                else if (playingField[currentRow + row, currentCol + col] == 'S')
                {
                    playingField[currentRow, currentCol] = '-';
                    playingField[currentRow + row, currentCol + col] = '-';
                    for (int i = 0; i < playingField.GetLength(0); i++)
                    {
                        for (int j = 0; j < playingField.GetLength(1); j++)
                        {
                            if (playingField[i, j] == 'S')
                            {
                                currentRow = i;
                                currentCol = j;
                                playingField[currentRow, currentCol] = 'M';
                                points -= 3;
                                return;
                            }
                        }
                    }
                }


            }
            else
            {
                Console.WriteLine("Don't try to escape the playing field!");
            }
        }

        private static bool isInRange(int row, int col)
        {
            return row >= 0 && row < playingField.GetLength(0) && col >= 0 && col < playingField.GetLength(1);
        }
    }
}
