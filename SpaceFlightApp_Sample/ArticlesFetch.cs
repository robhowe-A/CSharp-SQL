#if DEBUG
using Microsoft.EntityFrameworkCore;
using SpaceFlight_News_App.Data;
using SpaceFlight_News_App.Models;
using System;
using System.Collections;
using System.Text.Json;
using namespace Spaceflight_News;

public class ArticlesFetch
{
    private static string baseUrlSFNAPI = "https://api.spaceflightnewsapi.net/v3/articles";

    public static async Task<Article[]> GetAPIArticles()
    {
        //Fetch the SFNAPI articles string.
        //Endpoint gives 10 articles at a time
        //Call API to get the recent articles JSON string
        HttpClient client = new HttpClient();
        string responseBody = await client.GetStringAsync(baseUrlSFNAPI);

        var articlesarray = JsonSerializer.Deserialize<Article[]>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        //Array.Sort(articlesarray);
        return articlesarray;
    }
};

public class HyperLink
{
    public string Href { get; set; }
    public string TextContent { get; set; }

    public HyperLink(string Href, string TextContent)
    {
        this.Href = Href;
        this.TextContent = TextContent;
    }

    public override string ToString()
    {
    return $"<a href=\"{this.Href}\">{this.TextContent}</a>";
    }
};

#endif