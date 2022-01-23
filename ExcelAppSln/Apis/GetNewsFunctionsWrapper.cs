using System;
using NewsAPI.Constants;
using NewsAPI.Models;

namespace ExcelApp.Apis
{
    public static class GetNewsFunctionsWrapper
    {
        public static string[,] getPopularArticlesByNameAndDate(string name, DateTime fromDate)
        {
            var newsApiClient = ConnectToAPI.SetupConnectionToNewsApiClient();

            EverythingRequest req = new EverythingRequest
            {
                Q = name,
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = fromDate.ToUniversalTime()
            };

            try
            {
                var articlesResponse = newsApiClient.GetEverything(req);

                if (articlesResponse.Status == Statuses.Ok)
                {
                    // total results found
                    Console.WriteLine(articlesResponse.TotalResults);

                    string[,] listOfArticles = new string[articlesResponse.TotalResults, 5];

                    int articleCounter = 0;

                    // here's the first 20
                    foreach (var article in articlesResponse.Articles)
                    {
                        listOfArticles[articleCounter, 0] = article.Title;
                        listOfArticles[articleCounter, 1] = article.Author;
                        listOfArticles[articleCounter, 2] = article.Description;
                        listOfArticles[articleCounter, 3] = article.Url;
                        listOfArticles[articleCounter, 4] = article.PublishedAt.ToString();
                        articleCounter++;
                    }

                    return listOfArticles;
                    //return $"Articles found on {name} are {articlesResponse.TotalResults}";
                }
                else
                    return new[,] {
                    {
                        articlesResponse.Status.ToString(),
                        articlesResponse.Error.Message
                    }};
            }
            catch (Exception ex)
            {
                return new[,] {{"Exception", ex.Message}};
            }
        }
    }
}