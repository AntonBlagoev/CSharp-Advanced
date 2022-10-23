using System;
using System.Collections.Generic;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tuple> tupleList = new List<Tuple>();
            for (int i = 0; i < 3; i++)
            {
                object[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (i == 0)
                {
                    tupleList.Add(new Tuple($"{input[0]} {input[1]}", input[2]));
                }
                else
                {
                    tupleList.Add(new Tuple(input[0], input[1]));
                }
            }
            foreach (var tuple in tupleList)
            {
                Console.WriteLine(tuple);
            }
        }
    }
}
