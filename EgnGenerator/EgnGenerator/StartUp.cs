using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EgnGenerator
{
    internal class StartUp
    {
        static List<StringBuilder> egns = new List<StringBuilder>();
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter Birtday (format - YYYY.MM.DD): ");
                    StringBuilder egn = new StringBuilder();
                    int[] data = Console.ReadLine().Split(".").Select(int.Parse).ToArray();
                    if (data[0] < 1900 || data[0] > DateTime.Today.Year)
                        throw new InvalidYearException();
                    else if (data[1] < 1 || data[1] > 12)
                        throw new InvalidMonthException();
                    else if (data[2] < 1)
                        throw new InvalidDayException();
                    switch (data[1])
                    {
                        case 1: if (data[2] > 31) throw new InvalidDayException(); break;
                        case 2:
                            if (data[2] > 28 && data[0] % 4 != 0) throw new InvalidDayException();
                            else if (data[2] > 29 && data[0] % 4 == 0) throw new InvalidDayException();
                            break;
                        case 3: if (data[2] > 31) throw new InvalidDayException(); break;
                        case 4: if (data[2] > 30) throw new InvalidDayException(); break;
                        case 5: if (data[2] > 31) throw new InvalidDayException(); break;
                        case 6: if (data[2] > 30) throw new InvalidDayException(); break;
                        case 7: if (data[2] > 31) throw new InvalidDayException(); break;
                        case 8: if (data[2] > 31) throw new InvalidDayException(); break;
                        case 9: if (data[2] > 30) throw new InvalidDayException(); break;
                        case 10: if (data[2] > 31) throw new InvalidDayException(); break;
                        case 11: if (data[2] > 30) throw new InvalidDayException(); break;
                        case 12: if (data[2] > 31) throw new InvalidDayException(); break;
                    }
                    Console.Write("Enter birthplace (administrative area in Bulgaria): ");
                    string birthPlace = Console.ReadLine();
                    Console.Write("Enter gender (m/w): ");
                    var gender = Console.ReadLine();
                    if (gender != "m" && gender != "w")
                        throw new InvalidGenderException();
                    if (data[0] > 1999) data[1] += 40;
                    egn.Append(data[0].ToString().Substring(2, 2)).Append($"{data[1]:d2}").Append($"{data[2]:d2}");
                    switch (birthPlace.ToLower())
                    {
                        case "blagoevgrad": generateAllEgns(0, 43, egn, gender); break;
                        case "burgas": generateAllEgns(44, 93, egn, gender); break;
                        case "varna": generateAllEgns(94, 139, egn, gender); break;
                        case "veliko Tarnovo": generateAllEgns(140, 169, egn, gender); break;
                        case "vidin": generateAllEgns(170, 183, egn, gender); break;
                        case "vratsa": generateAllEgns(184, 217, egn, gender); break;
                        case "gabrovo": generateAllEgns(218, 233, egn, gender); break;
                        case "kardjali": generateAllEgns(234, 281, egn, gender); break;
                        case "kustendil": generateAllEgns(282, 301, egn, gender); break;
                        case "lovech": generateAllEgns(301, 319, egn, gender); break;
                        case "montana": generateAllEgns(320, 341, egn, gender); break;
                        case "pazardjik": generateAllEgns(342, 377, egn, gender); break;
                        case "pernik": generateAllEgns(378, 395, egn, gender); break;
                        case "pleven": generateAllEgns(396, 435, egn, gender); break;
                        case "plovdiv": generateAllEgns(436, 501, egn, gender); break;
                        case "razgrad": generateAllEgns(502, 527, egn, gender); break;
                        case "ruse": generateAllEgns(528, 555, egn, gender); break;
                        case "silistra": generateAllEgns(556, 575, egn, gender); break;
                        case "sliven": generateAllEgns(576, 601, egn, gender); break;
                        case "smolian": generateAllEgns(602, 623, egn, gender); break;
                        case "sofia-grad": generateAllEgns(624, 721, egn, gender); break;
                        case "sofia": generateAllEgns(722, 751, egn, gender); break;
                        case "stara Zagora": generateAllEgns(752, 789, egn, gender); break;
                        case "dobrich": generateAllEgns(790, 821, egn, gender); break;
                        case "targovishte": generateAllEgns(822, 843, egn, gender); break;
                        case "haskovo": generateAllEgns(844, 871, egn, gender); break;
                        case "shumen": generateAllEgns(872, 903, egn, gender); break;
                        case "yambol": generateAllEgns(904, 925, egn, gender); break;
                        case "other": generateAllEgns(926, 999, egn, gender); break;
                        default: throw new InvalidBirthPlaceException();
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("FORMAT_EXCEPTION: Enter birth date in the given format.");
                    Continue();
                    
                }
                catch (InvalidYearException e)
                {
                    Console.WriteLine(e.ToString());
                    Continue();
                }
                catch (InvalidMonthException e)
                {
                    Console.WriteLine(e.ToString());
                    Continue();
                }
                catch (InvalidDayException e)
                {
                    Console.WriteLine(e.ToString());
                    Continue();
                }
                catch (InvalidBirthPlaceException e)
                {
                    Console.WriteLine(e.ToString());
                    Continue();
                }
                catch (InvalidGenderException e) 
                {
                    Console.WriteLine(e.ToString());
                    Continue();
                }
            }
            for (int i = 0; i < egns.Count; i++) 
                tenthNumber(egns[i]);
            Console.WriteLine("-----All Possible EGNs-----");
            for (int i = 0; i < egns.Count; i++)
                Console.WriteLine($"{i+1:d2}. {egns[i]}");
        }

        private static void generateAllEgns(int start, int end, StringBuilder egn, string gender) 
        {
            for (int i = start; i <= end; i++)
            {
                var egnTo9thNum = new StringBuilder();
                egnTo9thNum.Append(egn).Append($"{i:d3}");
                if (int.Parse(egnTo9thNum.ToString()[8].ToString()) % 2 == 0 && gender == "m")
                    egns.Add(egnTo9thNum);
                if (int.Parse(egnTo9thNum.ToString()[8].ToString()) % 2 != 0 && gender == "w")
                    egns.Add(egnTo9thNum);
            }
        }
        private static void tenthNumber(StringBuilder egn) 
        {
            int sum = 0;
            sum += int.Parse(egn.ToString()[0].ToString())*2;
            sum += int.Parse(egn.ToString()[1].ToString())*4;
            sum += int.Parse(egn.ToString()[2].ToString())*8;
            sum += int.Parse(egn.ToString()[3].ToString())*5;
            sum += int.Parse(egn.ToString()[4].ToString())*10;
            sum += int.Parse(egn.ToString()[5].ToString())*9;
            sum += int.Parse(egn.ToString()[6].ToString())*7;
            sum += int.Parse(egn.ToString()[7].ToString())*3;
            sum += int.Parse(egn.ToString()[8].ToString())*6;
            int tenth = sum % 11;
            if (tenth == 10) tenth = 0;
            egn.Append(tenth);
        }
        private static void Continue() 
        {
            Console.WriteLine("--------\nPress 'Enter' to continue.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
