using System.Text.Json;
using Humanizer;

namespace WeatherApi;

public class PascalCaseNamingPolicy:JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        if (name.All(char.IsUpper))
            return name.ToLower().Pascalize();

        return name.Pascalize();
    }
}