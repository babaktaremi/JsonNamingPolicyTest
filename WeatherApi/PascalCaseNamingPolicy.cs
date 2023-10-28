using System.Text.Json;
using Humanizer;

namespace WeatherApi;

public class PascalCaseNamingPolicy:JsonNamingPolicy
{
    public override string ConvertName(string name)
    {

        return CamelCase.ConvertName(name).Pascalize();
    }
}