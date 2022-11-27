namespace LineNumbers
{
    using System.IO;
    using System;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (var reader = new StreamReader(inputFilePath))
            {
                using(StreamWriter writer = new StreamWriter(outputFilePath))
	            {
                    var line="";
                    int count = 1;
                    while ((line = reader.ReadLine()) != null) 
                    {
                        int letters = 0;
                        int signs = 0;
                        for (int i = 0; i < line.Length; i++)
			            {
                            if (Char.IsLetter(line[i])) 
                                letters++;
                            if (Char.IsPunctuation(line[i])) 
                                signs++;
			            }
                        writer.WriteLine($"Line {count}: {line} ({letters})({signs})");
                        count++;
                    }
	            }
            }
        }
    }
}
