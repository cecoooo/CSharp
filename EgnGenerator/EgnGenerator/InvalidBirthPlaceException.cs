using System;
using System.Collections.Generic;
using System.Text;
using EgnGenerator;

public class InvalidBirthPlaceException: Exception
{
    public override string ToString()
    {
        return $"INVALID_BIRTH_PLACE_EXCEPTION: It's not a regional city in Bulgaria.";
    }
}