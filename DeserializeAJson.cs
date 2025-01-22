using System.Text.Json;

namespace DeserializeExtra
{

    
public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureF { get; set; }
        //(_C) = [T(_F) - 32] / 1.8
        public int TemperatureC => (int)((TemperatureF - 32) / 1.8);
        public string? Summary { get; set; }
        public IList<Launch>? launches { get; set; }
        //TODO:
        //public ?IList<string> countyNames { get; set; }

    }

    public class Launch
    {
        public string? id { get; set; }
        public string? provider { get; set; }
    }
    

    public class DeserializeAJson
    {
        public static void Main()
        {
            string jsonString =
@"[
  {
    ""date"": ""2022-10-26"",
    ""temperatureF"": 74,
    ""summary"": ""Windy"",
    ""launches"": [{
        ""id"": ""df8d4fdb-9add-4ce9-9f0e-aae1c61df212"",
        ""provider"": ""Launch Library 2""
      }],
    ""countyNames"": [ ""Dallas"", ""Fort Worth"" ]
  }
]
";
            ////WORKING JSON DESERIALIE
            //var weatherforecast = JsonSerializer.Deserialize<WeatherForecast[]>(jsonString);
            var company = (WeatherForecast[]?)JsonSerializer.Deserialize(jsonString, typeof(WeatherForecast[]), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            // Original attempt
            // WeatherForecast? weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString);
            Console.WriteLine($"Date: {company?.ElementAt(0).Date}");
            Console.WriteLine($"TemperatureRanges: {company?.ElementAt(0).launches.ElementAt(0).provider}");
        }
    }
}