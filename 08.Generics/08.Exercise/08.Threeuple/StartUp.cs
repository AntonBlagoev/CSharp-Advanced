using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Threeuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tuple> tupleList = new List<Tuple>();
            for (int i = 0; i < 3; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (i == 0)
                {
                    tupleList.Add(new Tuple($"{input[0]} {input[1]}", input[2], string.Join(" ", input.Skip(3))));
                }
                else if (i == 1)
                {
                    tupleList.Add(new Tuple(input[0], input[1], IsDrunk(input[2])));
                }
                else
                {
                    tupleList.Add(new Tuple(input[0], double.Parse(input[1]), input[2]));
                }
            }
            foreach (var tuple in tupleList)
            {
                Console.WriteLine(tuple);
            }

        }
        public static bool IsDrunk(string item)
        {
            if (item == "drunk")
            {
                return true;
            }
            return false;
        }
    }
}
