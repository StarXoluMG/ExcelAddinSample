using System;
using NewsAPI;
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
                    string[,] listOfArticles = new string[articlesResponse.Articles.Count+1, 3];

                    int articleCounter = 0;

                    listOfArticles[articleCounter, 0] = "Title";
                    listOfArticles[articleCounter, 1] = "Url";
                    listOfArticles[articleCounter, 2] = "PublishedAt";

                    // here's the first 20
                    foreach (var article in articlesResponse.Articles)
                    {
                        articleCounter++;
                        listOfArticles[articleCounter, 0] = article.Title;
                        listOfArticles[articleCounter, 1] = article.Url;
                        listOfArticles[articleCounter, 2] = article.PublishedAt.ToString();
                        
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

        public static string[,] getHeadlines(string countryCode)
        {
            var newsApiClient = ConnectToAPI.SetupConnectionToNewsApiClient();

            ConversionUtility conversionUtility = new ConversionUtility();

            TopHeadlinesRequest req = new TopHeadlinesRequest()
            {
                Country = conversionUtility.getEnumFromString<Countries>(countryCode)
            };

            try
            {
                var articlesResponse = newsApiClient.GetTopHeadlines(req);

                if (articlesResponse.Status == Statuses.Ok)
                {
                    string[,] listOfArticles = new string[articlesResponse.Articles.Count + 1, 3];

                    int articleCounter = 0;

                    listOfArticles[articleCounter, 0] = "Title";
                    listOfArticles[articleCounter, 1] = "Url";
                    listOfArticles[articleCounter, 2] = "PublishedAt";

                    // here's the first 20
                    foreach (var article in articlesResponse.Articles)
                    {
                        articleCounter++;
                        listOfArticles[articleCounter, 0] = article.Title;
                        listOfArticles[articleCounter, 1] = article.Url;
                        listOfArticles[articleCounter, 2] = article.PublishedAt.ToString();

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
                return new[,] { { "Exception", ex.Message } };
            }
        }
    }
}