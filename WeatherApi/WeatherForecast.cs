namespace WeatherApi
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }
        

        public int TemperatureC { get; set; }

        public int TEMPRATUREF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
        public int CSDPortfolioCount { get; set; }
        public string ISIN { get; set; }
        public string Some_Property_With_UnderScore { get; set; }
        public string _OrderExpectedQuantity { get; set; }

        public string email { get; set; }
    }
}