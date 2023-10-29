using System.Text.Json;
using Humanizer;
using WeatherApi.Extensions;

namespace WeatherApi;

public class PascalCaseNamingPolicy:JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        return !name.StartsWithCapitalLetter() ? name : CamelCase.ConvertName(name).Pascalize();
    }
}