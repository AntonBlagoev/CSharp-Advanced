using System;

namespace _02.TruffleHunter
{
    class Program
    {
        private static int blackTruffelCount = 0;
        private static int whiteTruffelCount = 0;
        private static int summerTruffelCount = 0;
        private static int wildBoarCount = 0;


        private static char[,] matrix;

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
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);

                if (tokens[0] == "Collect")
                {
                    Move(row, col);
                }
                else if (tokens[0] == "Wild_Boar")
                {
                    string direction = tokens[3];

                    if (direction == "up")
                    {
                        for (int i = row; i >= 0; i--)
                        {
                            WildBoar(i, col);
                            i--;
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = row; i < n; i++)
                        {
                            WildBoar(i, col);
                            i++;
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = col; i >= 0; i--)
                        {
                            WildBoar(row, i);
                            i--;
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = col; i < n; i++)
                        {
                            WildBoar(row, i);
                            i++;
                        }
                    }
                }
                
            }

            Console.WriteLine($"Peter manages to harvest {blackTruffelCount} black, {summerTruffelCount} summer, and {whiteTruffelCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarCount} truffles.");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void WildBoar(int row, int col)
        {
            if (matrix[row, col] != '-')
            {
                wildBoarCount++;
                matrix[row, col] = '-';
            }
        }

        public static void Move(int row, int col)
        {
            if (matrix[row, col] == 'B')
            {
                blackTruffelCount++;
            }
            else if (matrix[row, col] == 'W')
            {
                whiteTruffelCount++;
            }
            else if (matrix[row, col] == 'S')
            {
                summerTruffelCount++;
            }
            matrix[row, col] = '-';
        }
    }
}
