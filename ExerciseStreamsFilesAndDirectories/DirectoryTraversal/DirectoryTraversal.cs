namespace DirectoryTraversal
{
    using Microsoft.VisualBasic;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using static System.Net.Mime.MediaTypeNames;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"C:\Users\User\Desktop\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string res = "";
            var files = Directory.GetFiles(inputFolderPath);
            for(int i = 0; i < files.Length; i++)
            {
                string fileName = "";
                long size = files[i].Length;
                for (int j = inputFolderPath.Length + 1; j < files[i].Length; j++)
                    fileName += files[i][j];
                files[i] = fileName;
            }
            var dict = new Dictionary<string, Dictionary<string, double>>();
            for (int i = 0; i < files.Length; i++)
            {
                string key = "";
                for (int j = files[i].Length-1; j >= 0; j--)
                {
                    key += files[i][j];
                    if (files[i][j] == '.')
                        break;
                }
                string reverse = String.Empty;
                for (int j = key.Length - 1; j > -1; j--)
                    reverse += key[j];
                if (!dict.ContainsKey(reverse))
                    dict.Add(reverse, new Dictionary<string, double>());
            }

            DirectoryInfo folder = new DirectoryInfo(inputFolderPath);
            FileInfo[] filesInfo = folder.GetFiles();
            double[] filesSizes = new double[filesInfo.Length];
            int c = 0;
            foreach (var item in filesInfo)
            {
                filesSizes[c] = Math.Round(item.Length / 1024.0, 3);
                c++;
            }

           
            for (int i = 0; i < files.Length; i++)
            {
                var innerDict = new Dictionary<string, double>();
                string key = "";
                for (int j = files[i].Length - 1; j >= 0; j--)
                {
                    key += files[i][j];
                    if (files[i][j] == '.')
                        break;
                }
                string reverse = string.Empty;
                for (int j = key.Length - 1; j > -1; j--)
                    reverse += key[j];
                for (int j = 0; j < files.Length; j++)
                {
                    string key1 = string.Empty;
                    for (int k = files[j].Length - 1; k >= 0; k--)
                    {
                        key1 += files[j][k];
                        if (files[j][k] == '.')
                            break;
                    }
                    string reverse1 = string.Empty;
                    for (int k = key1.Length - 1; k > -1; k--)
                        reverse1 += key1[k];
                    if (reverse == reverse1)
                        innerDict[files[j]] = filesSizes[j];
                }
                dict[reverse] = innerDict;
            }
            
            var newDict = dict.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            foreach (var item in newDict)
            {
                res += item.Key + "\n";
                var item1 = item.Value.OrderByDescending(x => x.Value);
                foreach (var pair in item1)
                {
                    res += $"--{pair.Key} - {pair.Value}kb\n";
                }
            }

            return res;
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            using (var writer = new StreamWriter(reportFileName))
            {
                writer.Write(textContent);
            }
        }
    }
}
