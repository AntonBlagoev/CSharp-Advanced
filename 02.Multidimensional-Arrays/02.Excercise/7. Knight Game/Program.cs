using System;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] chessBoard = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    chessBoard[row, col] = input[col];
                }
            }

            int countRemovedKnights = 0;

            while (true)
            {
                int countMostAttacking = 0;
                int rowMostAttacking = 0;
                int colMostAttacking = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        int attackedKnights = 0;

                        if (col > 1 && row > 0)   // check moving -2 horizontally, then 1 up vertically
                        {
                            if (chessBoard[row, col] == 'K' && chessBoard[row - 1, col - 2] == 'K')
                            {
                                attackedKnights++;
                            }
                        }

                        if (col > 0 && row > 1)   // check moving -1 horizontally, then 2 up vertically
                        {
                            if (chessBoard[row, col] == 'K' && chessBoard[row - 2, col - 1] == 'K')
                            {
                                attackedKnights++;
                            }
                        }

                        if (col < size - 1 && row > 1)   // check moving +1 horizontally, then 2 up vertically
                        {
                            if (chessBoard[row, col] == 'K' && chessBoard[row - 2, col + 1] == 'K')
                            {
                                attackedKnights++;
                            }
                        }

                        if (col < size - 2 && row > 0)   // check moving +2 horizontally, then 1 up vertically
                        {
                            if (chessBoard[row, col] == 'K' && chessBoard[row - 1, col + 2] == 'K')
                            {
                                attackedKnights++;
                            }
                        }

                        if (col < size - 2 && row < size - 1)   // check moving +2 horizontally, then 1 down vertically
                        {
                            if (chessBoard[row, col] == 'K' && chessBoard[row + 1, col + 2] == 'K')
                            {
                                attackedKnights++;
                            }
                        }

                        if (col < size - 1 && row < size - 2)   // check moving +1 horizontally, then 2 down vertically
                        {
                            if (chessBoard[row, col] == 'K' && chessBoard[row + 2, col + 1] == 'K')
                            {
                                attackedKnights++;
                            }
                        }

                        if (col > 0 && row < size - 2)   // check moving -1 horizontally, then 2 down vertically
                        {
                            if (chessBoard[row, col] == 'K' && chessBoard[row + 2, col - 1] == 'K')
                            {
                                attackedKnights++;
                            }
                        }

                        if (col > 1 && row < size - 1)   // check moving -2 horizontally, then 1 down vertically
                        {
                            if (chessBoard[row, col] == 'K' && chessBoard[row + 1, col - 2] == 'K')
                            {
                                attackedKnights++;
                            }
                        }

                        if (countMostAttacking < attackedKnights)
                        {
                            countMostAttacking = attackedKnights;
                            rowMostAttacking = row;
                            colMostAttacking = col;
                        }
                    }
                }

                if (countMostAttacking == 0)
                {
                    break;
                }
                else
                {
                    chessBoard[rowMostAttacking, colMostAttacking] = '0';
                    countRemovedKnights++;
                }

            }
            Console.WriteLine(countRemovedKnights);
        }
    }
}
