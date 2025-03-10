﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace DeserializeExtra
{

    
public class Article
	{
        public class articleService
        {
            
            public string title { get; }
            public string url { get; }
            public string imageUrl { get; }
            public string summary { get; }
            public DateTime publishedAt { get; }
            public Boolean featured {get; }

            public IList<Launch>? launches {get;}
        }
    }

    public class Launch
    {
        public string? id { get; set; }
        public string? provider { get; set; }
    }
    

    public class DeserializeComplexJson
    {
        public static void Main()
        {
            string jsonString =
@"[
  {
    ""id"": 16021,
    ""title"": ""Curiosity marks 10 years on Mars as discoveries continue"",
    ""url"": ""https://www.nasaspaceflight.com/2022/08/curiosity-10-years/"",
    ""imageUrl"": ""https://www.nasaspaceflight.com/wp-content/uploads/2014/12/2014-12-30-00_25_32-nasa-curiosity-Google-Search.jpg"",
    ""newsSite"": ""NASA Spaceflight"",
    ""summary"": ""After successfully landing on Mars on August 6, 2012 (UTC), Curiosity continues to unlock the secrets of the Red Planet as the vehicle explores Gale Crater. Since landing, the rover has traveled over 17.5 miles (28.1 km) and made multiple scientific discoveries. Curiosity is now in the process of exploring and traversing Mount Sharp, the 5.5-kilometer-high mountain that lies in the center of Gale Crater."",
    ""publishedAt"": ""2022-08-06T15:43:54.000Z"",
    ""updatedAt"": ""2022-08-06T15:56:45.516Z"",
    ""featured"": false,
    ""launches"": [
      {
        ""id"": ""df8d4fdb-9add-4ce9-9f0e-aae1c61df212"",
        ""provider"": ""Launch Library 2""
      }
    ],
    ""events"": []
  }
]
";
            ////WORKING JSON DESERIALIE
            //var weatherforecast = JsonSerializer.Deserialize<WeatherForecast[]>(jsonString);
            var articles = (Article[]?)JsonSerializer.Deserialize(jsonString, typeof(Article[]), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            // Original attempt
            // WeatherForecast? weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString);
            Console.WriteLine($"Date: {articles?.ElementAt(0).GetType()}");
            Console.WriteLine($"TemperatureRanges: {12345}");
        }
    }
}