using System;
using System.Collections.Generic;
using System.Text;
using EgnGenerator;

public class InvalidYearException : Exception
{
    public override string ToString()
    {
        return $"INVALID_YEAR_EXCEPTION: Year must be between 1900 and {DateTime.Now.Year}.";
    }
}