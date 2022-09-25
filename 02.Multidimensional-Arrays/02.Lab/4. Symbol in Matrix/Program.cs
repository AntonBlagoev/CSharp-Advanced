using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col].ToString();
                }
            }

            string symbolToFind = Console.ReadLine();
            bool isFinded = false;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (symbolToFind == matrix[row, col])
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFinded = true;
                        break;
                    }
                }
                if (isFinded)
                {
                    break;
                }
            }
            if (!isFinded)
            {
                Console.WriteLine($"{symbolToFind} does not occur in the matrix");
            }
        }
    }
}
