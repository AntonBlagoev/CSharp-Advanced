using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbesrDict = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                if (!numbesrDict.ContainsKey(inputNumber))
                {
                    numbesrDict.Add(inputNumber, 0);
                }
                numbesrDict[inputNumber]++;
            }
            Console.WriteLine(numbesrDict.Single(n => n.Value % 2 == 0).Key);

            //foreach (var number in numbesrDict)
            //{
            //    if (number.Value % 2 == 0)
            //    {
            //        Console.WriteLine(number.Key);
            //    }
            //}
        }
    }
}
