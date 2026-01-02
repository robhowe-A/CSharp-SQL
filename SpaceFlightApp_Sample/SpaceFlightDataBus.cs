// ==============================================================================
// Filename: SpaceFlightDataBus.cs
// 
// Author: Robert Howell
// Date: 6/24/2024
// Version: 1.2
//
// Description: This file is a data bus design database additions/changes.
//
// ==============================================================================

using System.Collections.Immutable;
using System.Text.Json;

namespace SpaceFlight_News_App.Models
{
    // <summary>
    //     SpaceFlightDataBus class is responsible for fetching/retrieving data from the database.
    //     Each object created creates a new database context.
    // </summary>
    public class SpaceFlightDataBus
    {
        private SpaceFlightDatabase? SpaceflightDatabase;

        public SpaceFlightDataBus() { }

        public async Task<APOD[]> GetApods()
        {

            var apods = new APOD[] { };

            try
            {
                //Fetch database apods
                SpaceflightDatabase = new SpaceFlightDatabase();
                apods = await SpaceflightDatabase.RetrieveApods();
                SpaceflightDatabase.Dispose();
            }
            catch (Exception ex)
            {

            }

            if (apods != null)
            {
                //Response body is not null
                return apods;
            }
            else
            {
                return [];
            }
        }

        public async Task<Article[]> GetArticles()
        {

            var articles = new Article[] { };
            try { 
                //Fetch database articles
                SpaceflightDatabase = new SpaceFlightDatabase();
                articles = await SpaceflightDatabase.RetrieveArticles();
                SpaceflightDatabase.Dispose();

                //Sort articles by date
                Array.Sort(articles, (article1, article2) => article2.date.CompareTo(article1.date));
            }
            catch (Exception ex)
            {

            }

            if (articles != null)
            {
                //Response data is not null
                return articles;
            }
            else
            {
                return [];
            }
        }

        public async Task<Article[]> GetArticles(DateTime currentDate)
        {

            var articles = new Article[] { };
            try
            {
                //Fetch database articles
                SpaceflightDatabase = new SpaceFlightDatabase();
                articles = await SpaceflightDatabase.RetrieveArticles(currentDate);
                SpaceflightDatabase.Dispose();

                //Sort articles by date
                Array.Sort(articles, (article1, article2) => article2.date.CompareTo(article1.date));
            }
            catch (Exception ex)
            {

            }

            if (articles != null)
            {
                //Response data is not null
                return articles;
            }
            else
            {
                return [];
            }
        }

        public async Task<Article[]> GetArticlesWithImages()
        {

            var articles = new Article[] { };
            try
            {
                //Fetch database articles
                SpaceflightDatabase = new SpaceFlightDatabase();
                articles = await SpaceflightDatabase.RetrieveArticlesWithImages();
                SpaceflightDatabase.Dispose();
            }
            catch (Exception ex)
            {

            }

            if (articles != null)
            {
                //Response data is not null
                return articles;
            }
            else
            {
                return [];
            }
        }

        public async Task<DateTime> GetOldestArticleDate()
        {
            var oldestArticleDate = new DateTime[] { };
            try
            {
                //Fetch database articles
                SpaceflightDatabase = new SpaceFlightDatabase();
                oldestArticleDate = await SpaceflightDatabase.RetrieveOldestArticleDateTime();
                SpaceflightDatabase.Dispose();
            }
            catch (Exception ex)
            {

            }

            if (oldestArticleDate.Length > 0)
            {
                //Response data is not null
                //hard data limited at 6/18. before that is non-consecutive, so trim
                //if (oldestArticleDate[0] >= new DateTime("2024", "06", "18")

                return oldestArticleDate[11];
            }
            else
            {
                return new DateTime();
            }
        }
        public async Task<Article[]> QueryArticleSites(string newsSiteInputValue)
        {

            var articles = new Article[] { };
            try
            {
                //Fetch database articles
                SpaceflightDatabase = new SpaceFlightDatabase();
                articles = await SpaceflightDatabase.QueryArticleSites(newsSiteInputValue);
                SpaceflightDatabase.Dispose();
            }
            catch (Exception ex)
            {

            }

            if (articles != null)
            {
                //Response data is not null
                return articles;
            }
            else
            {
                return [];
            }
        }
        
        public async Task<List<string>> GetNewsSites()
        {

            var articles = new List<string> { };
            try
            {
                //Fetch database articles
                SpaceflightDatabase = new SpaceFlightDatabase();
                articles = await SpaceflightDatabase.GetNewsSites();
                SpaceflightDatabase.Dispose();
            }
            catch (Exception ex)
            {

            }

            if (articles != null)
            {
                //Response data is not null
                return articles;
            }
            else
            {
                return [];
            }
        }

        public void CheckForDatabaseData()
        {
            try
            {
                SpaceflightDatabase = new SpaceFlightDatabase();
                SpaceflightDatabase.CheckForDataEmpty();
                SpaceflightDatabase.Dispose();
            }
            catch (Exception ex)
            {

            }
        }
    }
}