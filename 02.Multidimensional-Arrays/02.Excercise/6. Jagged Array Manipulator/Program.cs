using System;
using System.Linq;


namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedMatrix = new int[rows][];

            for (int row = 0; row < jaggedMatrix.GetLength(0); row++)
            {
                int[] inputCols = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();
                jaggedMatrix[row] = inputCols;
            }

            for (int row = 0; row < jaggedMatrix.GetLength(0) - 1; row++)
            {
                if (jaggedMatrix[row].Length == jaggedMatrix[row + 1].Length)
                {
                    for (int col = 0; col < jaggedMatrix[row].Length; col++)
                    {
                        jaggedMatrix[row][col] *= 2;
                        jaggedMatrix[row + 1][col] *= 2;
                    }

                }
                else
                {
                    for (int col = 0; col < jaggedMatrix[row].Length; col++)
                    {
                        jaggedMatrix[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedMatrix[row + 1].Length; col++)
                    {
                        jaggedMatrix[row + 1][col] /= 2;
                    }
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(tokens[1]);
                int column = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (row >= 0 && row < jaggedMatrix.GetLength(0) && column >= 0 && column < jaggedMatrix[row].Length)
                {
                    if (tokens[0] == "Add")
                    {
                        jaggedMatrix[row][column] += value;
                    }
                    else if (tokens[0] == "Subtract")
                    {
                        jaggedMatrix[row][column] -= value;
                    }
                }
            }

            for (int row = 0; row < jaggedMatrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", jaggedMatrix[row]));
            }

        }
    }
}
