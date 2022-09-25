using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedMatrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] cols = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedMatrix[row] = cols;
            }

            string inputCommand = string.Empty;
            while ((inputCommand = Console.ReadLine()) != "END")
            {
                string[] commands = inputCommand.Split();

                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int val = int.Parse(commands[3]);

                if (row >= 0 && row < rows && col >= 0 && col < jaggedMatrix[row].Length)
                {
                    if (commands[0] == "Add")
                    {
                        jaggedMatrix[row][col] += val;
                    }
                    else if (commands[0] == "Subtract")
                    {
                        jaggedMatrix[row][col] -= val;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedMatrix[i]));
            }
        }
    }
}
