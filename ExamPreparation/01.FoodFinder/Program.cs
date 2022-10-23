using System;
using System.Collections.Generic;

namespace _01.FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> vowels = new Queue<string>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries));

            Stack<string> consonants = new Stack<string>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries));

            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();
            words.Add("pear", new List<string>());
            words.Add("flour", new List<string>());
            words.Add("pork", new List<string>());
            words.Add("olive", new List<string>());

            while (consonants.Count != 0)
            {
                string currentVowel = vowels.Peek();
                string currentConsonant = consonants.Peek();
                
                CheckLetter(words, currentVowel);
                CheckLetter(words, currentConsonant);

                vowels.Dequeue();
                vowels.Enqueue(currentVowel);
                consonants.Pop();
            }

            int numberOfWordsFound = 0;
            List<string> wordsFound = new List<string>();

            foreach (var word in words)
            {
                string wordKey = word.Key;
                if (wordKey.Length == word.Value.Count)
                {
                    numberOfWordsFound++;
                    wordsFound.Add(wordKey);
                }
            }

            Console.WriteLine($"Words found: {numberOfWordsFound}");
            Console.WriteLine($"{string.Join(Environment.NewLine, wordsFound)}");
        }

        private static void CheckLetter(Dictionary<string, List<string>> words, string letter)
        {
            foreach (var word in words)
            {
                string wordKey = word.Key;
                if (wordKey.Contains(letter))
                {
                    if (!word.Value.Contains(letter))
                    {
                        word.Value.Add(letter);
                    }
                }
            }
        }
    }
}
