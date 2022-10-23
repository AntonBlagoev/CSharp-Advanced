using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TheBattleOfTheFiveArmies
{
    class Program
    {
        private static char[][] battleField;
        private static int armyRow;
        private static int armyCol;
        private static int orcsRow;
        private static int orcsCol;
        private static int armor;
        private static bool gameOver = false;

        static void Main(string[] args)
        {
            armor = int.Parse(Console.ReadLine());
            int numbersOfRows = int.Parse(Console.ReadLine());
            battleField = new char[numbersOfRows][];

            for (int row = 0; row < numbersOfRows; row++)
            {
                //string input = Console.ReadLine();
                //battleField[row] = new char[input.Length];
                char[] input = Console.ReadLine().ToCharArray();
                battleField[row] = input;

                for (int col = 0; col < input.Length; col++)
                {
                    //battleField[row][col] = input[col];
                    if (battleField[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }


            while (!gameOver)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                orcsRow = int.Parse(commands[1]);
                orcsCol = int.Parse(commands[2]);
                battleField[orcsRow][orcsCol] = 'O';

                if (commands[0] == "up")
                {
                    Move(-1, 0);
                }
                else if (commands[0] == "down")
                {
                    Move(1, 0);
                }
                else if (commands[0] == "left")
                {
                    Move(0, -1);
                }
                else if (commands[0] == "right")
                {
                    Move(0, 1);
                }
            }


            for (int i = 0; i < battleField.GetLength(0); i++)
            {
                for (int j = 0; j < battleField[i].Length; j++)
                {
                    Console.Write(battleField[i][j]);
                }
                Console.WriteLine();
            }
        }

        private static void Move(int row, int col)
        {
            battleField[armyRow][armyCol] = '-';
            armor--;
            
            if (isInRange((armyRow + row), (armyCol + col)))
            {
                armyRow += row;
                armyCol += col;

                if (battleField[armyRow][armyCol] == 'M')
                {
                    gameOver = true;
                    battleField[armyRow][armyCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    return;
                }
                else if (armor <= 0)
                {
                    gameOver = true;
                    battleField[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    return;
                }

                else if (battleField[armyRow][armyCol] == 'O')
                {
                    armor -= 2;
                    if (armor <= 0)
                    {
                        gameOver = true;
                        battleField[armyRow][armyCol] = 'X';
                        Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                        return;
                    }
                    else
                    {
                        battleField[armyRow][armyCol] = 'A';
                    }
                }
                else
                {
                    battleField[armyRow][armyCol] = 'A';
                }
            }
            else
            {
                if (armor <= 0)
                {
                    gameOver = true;
                    battleField[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    return;
                }
            }
        }

        private static bool isInRange(int row, int col)
        {
            return row >= 0 && row < battleField.GetLength(0) && col >= 0 && col < battleField[row].Length;
        }
    }
}
