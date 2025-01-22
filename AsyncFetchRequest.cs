using System;
using System.IO;
using System.Net.Http;

namespace FetchRequest
{
    class FetchRequest
    {
        private static string baseUrl = "https://api.spaceflightnewsapi.net/v3/articles";
        private static HttpClient client = new HttpClient();
        private static string filePath;

        static async void AsyncFetchRequest()
        {
            filePath = "C:\\dev\\C#\\Projects\\CSProjects\\CSProjects\\JSON\\december21.json";
            string responseBody = await client.GetStringAsync(baseUrl);
            File.WriteAllText(filePath, responseBody);
        }
        static void Main()
        {
            AsyncFetchRequest();
        }
    }
}