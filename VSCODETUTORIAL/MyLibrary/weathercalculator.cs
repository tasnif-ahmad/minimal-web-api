using System;

namespace MyWebAPI.MyLibrary;

public static class weathercalculator
{
    public static string DetermineSeason(DateOnly date)
    {
        int month = date.Month;

        switch (month)
        {
            case >= 3 and <= 5:
                return "Spring";
            case >= 6 and <= 8:
                return "Summer";
            case >= 9 and <= 11:
                return "Autumn";
            default:
                return "Winter";
        }
    }
}
