namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader wordReader = new StreamReader(wordsFilePath))
            {
                var wordDict = wordReader.ReadLine().Split(' ', '.', '-', ',').ToDictionary(key => key, value => 0);

                using (StreamReader textReader = new StreamReader(textFilePath))
                {
                    while (!textReader.EndOfStream)
                    {
                        string[] textLine = textReader.ReadLine().Split(' ', '.', '-', ',');
                        foreach (var text in textLine)
                        {
                            if (wordDict.ContainsKey(text.ToLower()))
                            {
                                wordDict[text.ToLower()]++;
                            }
                        }
                    }

                    using (StreamWriter outputWriter = new StreamWriter(outputFilePath))
                    {
                        foreach (var word in wordDict.OrderByDescending(x => x.Value))
                        {
                            outputWriter.WriteLine($"{word.Key} - {word.Value}");
                        }
                    }
                }
            }
        }
    }
}
