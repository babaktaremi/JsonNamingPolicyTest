using System.Text.Json;
using Humanizer;

namespace WeatherApi;

public class PascalCaseNamingPolicy:JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        var resolver = CamelCase;

        return resolver.ConvertName(name).Pascalize();
    }
}