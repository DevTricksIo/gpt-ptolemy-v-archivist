namespace ConsoleArchivist.Helpers;

public static class StringExtensions
{
    //Convert a string to equivalent boolean. Return null if can not converts
    public static bool Boolify(this string str)
    {
        if (str == null) return false; 
        var trimString = str.Trim().ToLower();

        var isBoolean = Boolean.TryParse(trimString, out bool value);

        if (isBoolean)
        {
            return value;
        }

        return false;
    }
}
