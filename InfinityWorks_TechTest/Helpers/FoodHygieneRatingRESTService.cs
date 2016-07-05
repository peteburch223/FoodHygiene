using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace InfinityWorks_TechTest.Helpers
{
    public interface IFoodHygieneRESTService
    {
        String getAPIData(String endPoint);
    }

    public class FoodHygieneRatingRESTService : IFoodHygieneRESTService
    {
        private readonly string baseUri = "http://api.ratings.food.gov.uk/";
        private HttpClient client;

        public String messageContent { get; set; }

        public FoodHygieneRatingRESTService(HttpClient client)
        {
            this.client = client;
        }

        public String getAPIData(String endPoint)
        {
            using (client)
            {
                configureApiHeader();
                Task<String> response = client.GetStringAsync(endPoint);
                return response.Result;
            }
        }

        private void configureApiHeader()
        {
            client.BaseAddress = new Uri(baseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-api-version", "2");
        }
    }

    public class Meta
    {
        public string dataSource { get; set; }
        public string extractDate { get; set; }
        public int itemCount { get; set; }
        public string returncode { get; set; }
        public int totalCount { get; set; }
        public int totalPages { get; set; }
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }
}