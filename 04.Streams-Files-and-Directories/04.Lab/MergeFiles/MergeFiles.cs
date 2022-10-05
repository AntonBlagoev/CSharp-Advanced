namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            SortedSet<int> mergedData = new SortedSet<int>();

            using (StreamReader reader = new StreamReader(firstInputFilePath))
            {
                while (!reader.EndOfStream)
                {
                    mergedData.Add(int.Parse(reader.ReadLine()));
                }
            }
            using (StreamReader reader = new StreamReader(secondInputFilePath))
            {
                while (!reader.EndOfStream)
                {
                    mergedData.Add(int.Parse(reader.ReadLine()));
                }
            }
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var item in mergedData)
                {
                    writer.WriteLine(item);
                }
            }






        }
    }
}
