namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream input = new FileStream(@"..\..\..\copyMe.png", FileMode.Open))
            {
                byte[] buffer = new byte[input.Length];
                input.Read(buffer);

                using (FileStream output = new FileStream(@"..\..\..\copyMe-copy.png", FileMode.Create))
                {
                    output.Write(buffer);
                }
            }
        }
    }
}
