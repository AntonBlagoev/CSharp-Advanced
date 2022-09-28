using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> wordsDict = new Dictionary<char, int>(); // or SortedDictionary

            string inputChars = Console.ReadLine();

            for (int i = 0; i < inputChars.Length; i++)
            {
                if (!wordsDict.ContainsKey(inputChars[i]))
                {
                    wordsDict.Add(inputChars[i], 0);
                }
                wordsDict[inputChars[i]]++;
            }

            foreach (var item in wordsDict.OrderBy(n => n.Key).ToDictionary(x => x.Key, x => x.Value))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }


        }
    }
}
