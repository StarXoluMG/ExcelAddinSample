using System.Configuration;
using System.Net;
using NewsAPI;

namespace ExcelApp.Apis
{
    public class ConnectToAPI
    {
        public static NewsApiClient SetupConnectionToNewsApiClient()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var newsApiClient = new NewsApiClient(ConfigurationManager.AppSettings["NewsAPIKey"]);
            return newsApiClient;
        }
    }
}