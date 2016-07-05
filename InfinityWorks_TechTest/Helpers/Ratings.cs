using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace InfinityWorks_TechTest.Helpers
{
    public interface IRatings
    {
        List<Rating> ratings { get; set; }
        List<String> getAll();
    }

    public class Ratings : IRatings
    {
        public List<Rating> ratings { get; set; }
        public Meta meta { get; set; }
        public List<Link> links { get; set; }

        private static readonly String endPoint = "Ratings";
        private IFoodHygieneRESTService _service;

        public Ratings(IFoodHygieneRESTService service)
        {
            _service = service;
        }

        public List<String> getAll()
        {
            ratings =  JsonConvert.DeserializeObject<Ratings>(_service.getAPIData(endPoint)).ratings;
            return prepareAsString(ratings);
        }

        private List<String> prepareAsString(List<Rating> ratings)
        {
            List<String> result = new List<string>();
            foreach (Rating rating in ratings)
            {
                result.Add(rating.ratingName);
            }
            return result;
        }
    }

    public class Rating
    {
        public int ratingId { get; set; }
        public string ratingName { get; set; }
        public string ratingKey { get; set; }
        public string ratingKeyName { get; set; }
        public int schemeTypeId { get; set; }
        public List<Link> links { get; set; }
    }
}