namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath);
            }
            Directory.CreateDirectory(outputPath);

            //CopyDirectory.CopyAllFiles(inputPath, outputPath);

            string[] files = Directory.GetFiles(inputPath);

            foreach (var file in files)
            {
                string sourceFileName = Path.GetFileName(file);
                string destFileName = Path.Combine(outputPath, sourceFileName);
                File.Copy(file, destFileName);
            }
        }
    }
}
