using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TilesMaster
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<int> whiteTiles = new Stack<int>(
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> greyTiles = new Queue<int>(
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> countOfTilles = new Dictionary<string, int>();
            
            countOfTilles.Add("Sink", 0);
            countOfTilles.Add("Oven", 0);
            countOfTilles.Add("Countertop", 0);
            countOfTilles.Add("Wall", 0);
            countOfTilles.Add("Floor", 0);
            

            while (whiteTiles.Count != 0 && greyTiles.Count != 0)
            {
                if (whiteTiles.Peek() == greyTiles.Peek())
                {
                    int areaOfTiles = whiteTiles.Peek() + greyTiles.Peek();

                    if (areaOfTiles == 40)
                    {
                        countOfTilles["Sink"] += 1;
                    }
                    else if (areaOfTiles == 50)
                    {
                        countOfTilles["Oven"] += 1;
                    }
                    else if (areaOfTiles == 60)
                    {
                        countOfTilles["Countertop"] += 1;
                    }
                    else if (areaOfTiles == 70)
                    {
                        countOfTilles["Wall"] += 1;
                    }
                    else
                    {
                        countOfTilles["Floor"] += 1;
                    }

                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                }
                else
                {
                    int tmpWhite = whiteTiles.Peek() / 2;
                    int tmpGrey = greyTiles.Peek();

                    whiteTiles.Pop();
                    greyTiles.Dequeue();

                    whiteTiles.Push(tmpWhite);
                    greyTiles.Enqueue(tmpGrey);
                }

            }


            if (whiteTiles.Count > 0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            else
            {
                Console.WriteLine($"White tiles left: none");
            }

            if (greyTiles.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: none");
            }

            foreach (var item in countOfTilles.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

        }
    }
}
