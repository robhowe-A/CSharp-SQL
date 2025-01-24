/*
 * Description: This program tests a json string deserialization for programmatic access
 * to the JSON properties.
 * Tested: 1-23-2025
 * Author: Robert Howell
 */

using System.Text.Json;

namespace DeserializeExtra
{
  internal class Article
  {
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public DateTime PublishedAt { get; set; }
    public Boolean Featured { get; set; }

    public IList<Launch>? Launches { get; set; }
  };

  internal class Launch
  {
    public string? Id { get; set; } = string.Empty;
    public string? Provider { get; set; } = string.Empty;
  };

  internal class DeserializeComplexJson
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
          ""provider"": ""Lah Library 2""
        }
      ],
      ""events"": []
    }
  ]
  ";
      // Deserialize Json to an object
      var articles = JsonSerializer.Deserialize<Article[]>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

      // Original attempt
      Console.WriteLine($"Date: {articles!.ElementAt(0).PublishedAt}");
      Console.WriteLine($"Title: {articles!.ElementAt(0).Title}");
      Console.WriteLine($"Launches: {articles!.ElementAt(0).Launches!.ElementAt(0).Provider}");
    }
  };
}