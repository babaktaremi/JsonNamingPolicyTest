namespace WeatherApi.Extensions;

public static class StringExtensions
{
    public static bool StartsWithCapitalLetter(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return false;
        }

        char firstChar = str[0];
        return char.IsUpper(firstChar);
    }
}