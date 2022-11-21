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
            string res = "";
            using (StreamReader reader = File.OpenText(inputFilePath))
            {
                int count = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (count % 2 == 0)
                    {
                        string newLine = "";
                        for (int i = 0; i < line.Length; i++)
                        {
                            char c = line[i];

                            if (c == '-' || c == ',' || c == '.' || c == ',' || c == '!' || c == '?')
                            {
                                newLine += '@';
                                continue;
                            }
                            newLine += line[i];
                        }
                        string[] arr = newLine.Split();
                        for (int i = arr.Length - 1; i >= 0; i--)
                        {
                            res += arr[i] + " ";
                        }
                        res += "\n";
                    }
                    count++;
                }
            }
            return res;
        }
    }
}
