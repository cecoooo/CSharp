using System;
using System.Collections.Generic;
using System.Text;
using DefiningClasses;

public class DateModifier
{
    public int DayDifference(string firstDate, string secondDate) 
    {
        int dayDiff = 0;
        firstDate += ' ';
        secondDate += ' ';
        int[] arrFirst = new int[3];
        int[] arrSecond = new int[3];
        string textFirst = string.Empty;
        string textSecond = string.Empty;
        int c = 0;
        for (int i = 0; i < 10; i++)
        {
            if (firstDate[i] == ' ')
            {
                arrFirst[c] = int.Parse(textFirst);
                arrSecond[c] = int.Parse(textSecond);
                c++;
                continue;
            }
            if (i!=0) 
            {
                if (firstDate[i-1] == ' ' && firstDate[i] == '0')
            }
            textFirst += firstDate[i];
            textSecond += secondDate[i];
        }
        for (int i = min(arrFirst[0], arrSecond[0]); i <= max(arrSecond[0], arrFirst[0]); i++)
        {

        }


        return dayDiff;
    }
    private int max(int n, int m) 
    {
        if (n > m)
            return n;
        else
            return m;
    }
    private int min(int n, int m)
    {
        if (n > m)
            return n;
        else
            return m;
    }
}
