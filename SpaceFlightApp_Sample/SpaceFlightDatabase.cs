// ==============================================================================
// Filename: SpaceFlightDatabase.cs
// 
// Author: Robert Howell
// Date: 6/24/2024
// Version: 1.2
//
// Description: This file hold the database class, using connection context for
// data transactions.
//
// ==============================================================================

using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace SpaceFlight_News_App.Models
{
    internal sealed class SpaceFlightDatabase : IDisposable
    {
        public bool isArticleEmpty = true;
        public bool isApodEmpty = true;
        private readonly []MySQLContext _context;
        public SpaceFlightDatabase()
        {
            if (_context == null)
            {
                try
                {
                    //Create a context for this backend request to use
                    IConfiguration configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json") //connection string is in appsettings.json
                        .Build();

                    _context = new []MySQLContext(configuration.GetConnectionString("[]MySQLContext") ?? throw new NullReferenceException("Failed to fetch the connection string."));
                }
                catch (Exception ex)
                {

                }
            }
        }
        public SpaceFlightDatabase([]MySQLContext context)
        {
            _context = context;
        }

        ~SpaceFlightDatabase()
        {
            ContextDispose();
        }

        public async Task<Article[]> RetrieveArticles()
        {
            //Reference the current date for article retrieval
            DateTime targetDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            //Return only the latest articles from the database
            var newestTenArticles = (from a in _context.Article orderby a.articleNum where a.date.Date == targetDate select a);
            return await newestTenArticles.ToArrayAsync();
        }

        public async Task<Article[]> RetrieveArticles(DateTime currentDate)
        {
            //Reference the current date for article retrieval
            DateTime targetDate = new DateTime(int.Parse(currentDate.Date.Year.ToString()), int.Parse(currentDate.Date.Month.ToString()), int.Parse(currentDate.Date.Day.ToString()));

            //Return only the latest articles from the database
            var newestTenArticles = (from a in _context.Article orderby a.articleNum where a.date.Date == targetDate select a);
            return await newestTenArticles.ToArrayAsync();
        }

        public async Task<Article[]> RetrieveArticlesWithImages()
        {
            //Return only the latest articles from the database
            var newestTenArticles = (from a in _context.Article where !string.IsNullOrEmpty(a.textURL) orderby a.articleNum descending select a);

            return await newestTenArticles.ToArrayAsync();
        }

        public async Task<DateTime[]> RetrieveOldestArticleDateTime()
        {
            //Return only the latest articles from the database
            var oldestArticleDate = (from a in _context.Article orderby a.date ascending where a.date >= new DateTime(2024, 06, 18) select a.date).Take(20);

            return await oldestArticleDate.ToArrayAsync();
        }

        public async Task<APOD[]> RetrieveApods()
        {
            //Return only the latest APOD from the database
            var newestAPOD = (from a in _context.APOD orderby a.id descending select a).Take(1);

            return await newestAPOD.ToArrayAsync();
        }

        public async Task<Article[]> QueryArticleSites(string newsSiteInputValue)
        {
            //Return the articles matching a provider
            var newSiteArticles = from a in _context.Article where a.newsSite == @$"{newsSiteInputValue}" select a;

            return await newSiteArticles.ToArrayAsync();
        }

        public async Task<List<string>> GetNewsSites()
        {
            //Get the news sites from the Article table
            var newsSites = from a in _context.Article select a.newsSite;
            
            return await newsSites.Distinct().ToListAsync();
        }
        public void CheckForDataEmpty()
        {

            // Check for articles.
            if (!_context.Article.Any())
            {
                SeedArticleDatabase();
            }
            isArticleEmpty = false;

            // Check for APODs.
            if (!_context.APOD.Any())
            {
                SeedApodDatabase();
            }
            isApodEmpty = false;

            ContextDispose();
        }

        //TODO: add apod database
        // private async Task<APOD SetApods() { //Add Apods to database};
        private void SeedArticleDatabase()
        {
            _context.Article.AddRange(
                new Article
                {
                    id = 21508,
                    title = "Rocket Factory Augsburg perceives historic moment for European launch industry",
                    url = "https://spacenews.com/rocket-factory-augsburg-perceives-historic-moment-for-european-launch-industry/",
                    textURL = "https://spacenews.com/wp-content/uploads/2023/10/RFA_LaunchPad_1-scaled-1-300x165.jpeg",
                    summary = "Startup Rocket Factory Augsburg perceive an historic shift has occurred in Europe launch, just as the firm closes in on its first orbital launch attempt.",
                    date = new DateTime(
                        2023, 11, 15,
                        20, 19, 22, 000),
                    featured = false,
                    newsSite = "SpaceFlightApp"
                });
            _context.SaveChanges();
        }
        private void SeedApodDatabase()
        {
            _context.APOD.AddRange(
                new APOD
                {
                    apodtitle = "Daytime Moon Meets Morning Star",
                    date = "2023-11-16",
                    hdurl = "https://apod.nasa.gov/apod/image/2311/Katarzyna20.jpg",
                    description = "Venus now appears as Earth's brilliant morning star, shining above the southeastern horizon before dawn. For early morning risers, the silvery celestial beacon rose predawn in a close pairing with a waning crescent Moon on Thursday, November 9. But from some northern locations, the Moon was seen to occult or pass in front of Venus. From much of Europe, the lunar occultation could be viewed in daylight skies. This time series composite follows the daytime approach of Moon and morning star in blue skies from Warsaw, Poland. The progression of eight sharp telescopic snapshots, made between 10:56am and 10:58am local time, runs from left to right, when Venus winked out behind the bright lunar limb.",
                    media = "image"
                });
            _context.SaveChanges();
        }
        private void ContextDispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            else
            {

            }
        }
        public void Dispose()
        {
            ContextDispose();
        }
    }
}