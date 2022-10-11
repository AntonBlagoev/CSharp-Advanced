using System;
using System.Linq;
using System.Collections.Generic;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
            string[,] matrix = new string[dimensions[0], dimensions[1]];

            string snakeInput = Console.ReadLine();
            Queue<string> snake = new Queue<string>();

            for (int i = 0; i < snakeInput.Length; i++)
            {
                snake.Enqueue(snakeInput[i].ToString());
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        string tmpSnake = snake.Dequeue();
                        snake.Enqueue(tmpSnake);
                        matrix[row, col] = tmpSnake;
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        string tmpSnake = snake.Dequeue();
                        snake.Enqueue(tmpSnake);
                        matrix[row, col] = tmpSnake;
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
