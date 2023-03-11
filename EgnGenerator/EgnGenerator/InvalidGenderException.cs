using System;
using System.Collections.Generic;
using System.Text;
using EgnGenerator;

public class InvalidGenderException : Exception
{
    public override string ToString()
    {
        return $"INVALID_GENDER_EXCEPTION: There are only two genders - m & w (man and woman).";
    }
}