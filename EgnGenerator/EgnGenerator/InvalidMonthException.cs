using System;
using System.Collections.Generic;
using System.Text;
using EgnGenerator;

public class InvalidMonthException : Exception
{
    public override string ToString()
    {
        return $"INVALID_MONTH_EXCEPTION: Months are between 01-12.";
    }
}