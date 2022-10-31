namespace LineNumbers
{
    using System.IO;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\input.txt";
            string outputFilePath = @"..\..\..\output.txt";

            RewriteFileWithLineNumbers(inputFilePath, outputFilePath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(@"..\..\..\input.txt");
            var writer = new StreamWriter(@"..\..\..\output.txt");
            var count = 1;
            using (writer)
            {
                using (reader)
                {
                    do
                    {
                        var line = reader.ReadLine();
                        if (line == null) break;
                        writer.WriteLine($"{count}. " + line);
                        count++;
                    } while (true);
                }
            }
        }
    }
}