using System;

namespace _02.Survivor
{
    class Program
    {
        private static char[][] matrix;

        static void Main(string[] args)
        {
            int numbersOfRows = int.Parse(Console.ReadLine());
            matrix = new char[numbersOfRows][];

            for (int i = 0; i < numbersOfRows; i++)
            {
                char[] input = Console.ReadLine().Replace(" ", "").ToCharArray();
                matrix[i] = input;
            }

            int countOfCollected = 0;
            int countOfOpponentsTokens = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] commands = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Find")
                {
                    int row = int.Parse(commands[1]);
                    int col = int.Parse(commands[2]);

                    if (isInRange(row, col))
                    {
                        countOfCollected += TokensCount(row, col);
                    }
                }
                else if (commands[0] == "Opponent")
                {
                    int row = int.Parse(commands[1]);
                    int col = int.Parse(commands[2]);
                    string direction = commands[3];

                    if (direction == "up")
                    {
                        for (int i = row; i >= row - 3; i--)
                        {
                            if (!isInRange(i, col))
                            {
                                break;
                            }
                            countOfOpponentsTokens += TokensCount(i, col);
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = row; i <= row + 3; i++)
                        {
                            if (!isInRange(i, col))
                            {
                                break;
                            }
                            countOfOpponentsTokens += TokensCount(i, col);
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = col; i >= col - 3; i--)
                        {
                            if (!isInRange(row, i))
                            {
                                break;
                            }
                            countOfOpponentsTokens += TokensCount(row, i);
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = col; i <= col + 3; i++)
                        {
                            if (!isInRange(row, i))
                            {
                                break;
                            }
                            countOfOpponentsTokens += TokensCount(row, i);
                        }
                    }
                }
            }

            for (int i = 0; i < numbersOfRows; i++)
            {
                Console.WriteLine(string.Join(' ', matrix[i]));
            }

            Console.WriteLine($"Collected tokens: {countOfCollected}");
            Console.WriteLine($"Opponent's tokens: {countOfOpponentsTokens}");

        }

        private static int TokensCount(int row, int col)
        {
            int count = 0;
            if (matrix[row][col] == 'T')
            {
                count++;
                matrix[row][col] = '-';
            }
            return count;
        }

        private static bool isInRange(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }
    }
}
