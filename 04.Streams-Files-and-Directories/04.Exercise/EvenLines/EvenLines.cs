namespace EvenLines
{
    using System;
    using System.IO;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {

            string outpuFilePath = @"..\..\..\output.txt";

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outpuFilePath))
                {
                    int rowCount = 1;
                    while (!reader.EndOfStream)
                    {
                        string[] line = reader.ReadLine().Split();

                        if (rowCount++ % 2 == 1)
                        {
                            for (int i = line.Length - 1; i >= 0; i--)
                            {
                                char[] tmpCharArray = line[i].ToCharArray();
                                for (int j = 0; j < tmpCharArray.Length; j++)
                                {
                                    if (tmpCharArray[j] == '-' || tmpCharArray[j] == ',' || tmpCharArray[j] == '.' || tmpCharArray[j] == '!' || tmpCharArray[j] == '?')
                                    {
                                        tmpCharArray[j] = '@';
                                    }
                                }
                                writer.Write(new string(tmpCharArray));
                                writer.Write(" ");
                            }
                            writer.WriteLine();
                        }
                    }
                }
            }
            return File.ReadAllText(outpuFilePath);
        }
    }
}
