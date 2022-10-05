namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    int countRows = 1;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        char[] lineChars = line.ToCharArray();
                        int countLetters = 0;
                        int countMarkers = 0;

                        foreach (var item in lineChars)
                        {
                            if (Char.IsLetter(item))
                            {
                                countLetters++;
                            }
                            else if (item == '.' || item == ','|| item == '\'' || item == '-' || item == '?' || item == '!')
                            {
                                countMarkers++;
                            }
                        }
                        writer.WriteLine($"Line {countRows}: {line}. ({countLetters}({countMarkers}))");
                        countRows++;
                    }

                }
            }
        }
    }
}
