namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo dir = new DirectoryInfo(@"..\..\..\Files\TestFolder");
            FileInfo[] infos = dir.GetFiles("*", SearchOption.AllDirectories);

            double sum = 0;

            foreach (FileInfo fileInfo in infos)
            {
                sum += fileInfo.Length;
            }

            sum = sum / 1024;

            File.WriteAllText(@"..\..\..\Files\output.txt", sum.ToString());
        }
    }
}
