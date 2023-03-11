using System;
using System.Collections.Generic;
using System.Text;
using EgnGenerator;

public class InvalidDayException : Exception
{
    public override string ToString()
    {
        return $"INVALID_DAY_EXCEPTION: Invalid number for a day in this month.";
    }
}