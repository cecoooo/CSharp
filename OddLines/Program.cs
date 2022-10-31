namespace OddLines
{
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\input.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            var writer = new StreamWriter(outputFilePath);
            int count = 0;
            using (writer)
            {
                using (reader)
                {
                    do
                    {
                        var line = reader.ReadLine();
                        if (line == null) break;
                        if (count%2==1) writer.WriteLine(line);
                        count++;
                    } while (true);
                }
            }
        }
    }
}
