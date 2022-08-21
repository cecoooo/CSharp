namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\words.txt";
            string textPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordParh, string textPath, string outputPath)
        {
            var dict = new Dictionary<string, int> { };
            using (var inputWord = new StreamReader(wordParh))
            {
                bool t = true;
                do
                {
                    string word = "";
                    do
                    {
                        char c = (char)inputWord.Read();
                        if (!Char.IsLetter(c))
                        {
                            if (inputWord.EndOfStream)
                            {
                                t = false;
                                break;
                            }
                            break;
                        }
                        word += c;
                    } while (true);
                    word = word.ToLower();
                    int count = 0;
                    bool f = true;
                    using (var inputTetx = new StreamReader(textPath))
                    {
                        do
                        {
                            string wordComp = "";
                            do
                            {
                                char c = (char)inputTetx.Read();
                                if (!Char.IsLetter(c))
                                {
                                    if (inputTetx.EndOfStream) f = false;
                                    break;
                                }
                                wordComp += c;
                            } while (f);
                            wordComp = wordComp.ToLower();
                            if (word == wordComp) count++;
                        } while (f);
                    }
                    if (count != 0) dict[word] = count;
                } while (t);
                var list = dict.OrderByDescending(x => x.Value).ToList();
                using (var output = new StreamWriter(outputPath))
                {
                    var dict1 = new Dictionary<string, int>(list.Count);
                    foreach (var item in list) output.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}