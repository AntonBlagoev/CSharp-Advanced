namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";


            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            SortedDictionary<string, List<FileInfo>> extensionsDict = new SortedDictionary<string, List<FileInfo>>();
            FileInfo[] files = new DirectoryInfo(inputFolderPath).GetFiles();

            foreach (var file in files)
            {
                if (!extensionsDict.ContainsKey(file.Extension))
                {
                    extensionsDict.Add(file.Extension, new List<FileInfo>());
                }
                extensionsDict[file.Extension].Add(file);
            }

            var orderedExtensionsDict = extensionsDict.OrderByDescending(x => x.Value.Count);

            StringBuilder sb = new StringBuilder();

            foreach (var extension in orderedExtensionsDict)
            {
                sb.AppendLine(extension.Key);

                var orderedFiles = extension.Value.OrderByDescending(x => x.Length);

                foreach (var file in orderedFiles)
                {
                    sb.AppendLine($"--{file.Name} - {(double)file.Length / 1024:f3}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(filePath, textContent);
        }
    }
}
