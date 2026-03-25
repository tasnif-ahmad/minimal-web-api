namespace MyLibrary;

public static class weathercalculator
{
    public static string DetermineSeason(DateOnly date)
    {
        int month = date.Month;

        return month switch
        {
            3 or 4 or 5 => "Spring",
            6 or 7 or 8 => "Summer",
            9 or 10 or 11 => "Autumn",
            _ => "Winter"
        };
    }
}