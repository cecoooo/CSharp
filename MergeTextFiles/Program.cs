namespace MergeFiles
{
    using System;
    using System.IO;

    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\input1.txt";
            var secondInputFilePath = @"..\..\..\input2.txt"; 
            var outputFilePath = @"..\..\..\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (var output = new StreamWriter(outputFilePath))
            {
                using (var first = new StreamReader(firstInputFilePath))
                {
                    using (var second = new StreamReader(secondInputFilePath))
                    {
                        do
                        {
                            if (!first.EndOfStream)
                            {
                                var line = first.ReadLine();
                                output.WriteLine(line);
                            }
                            if (!second.EndOfStream)
                            {
                                var line = second.ReadLine();
                                output.WriteLine(line);
                            }
                        } while (!first.EndOfStream || !second.EndOfStream);
                    }
                }
            }
        }
    }
}
