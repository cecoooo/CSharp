namespace ExtractSpecialBytes
{
    using System.IO;

    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\example.png";
            string bytesFilePath = @"..\..\..\bytes.txt";
            string outputPath = @"..\..\..\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (var image = new StreamReader(binaryFilePath))
            {
                using (var binary = new StreamWriter(outputPath))
                {
                    do
                    {
                        byte buffer = byte.MaxValue;
                        image.Read((char)buffer, 0, byte.MaxValue);
                    } while (image.EndOfStream);
                }
            }
        }
    }
}