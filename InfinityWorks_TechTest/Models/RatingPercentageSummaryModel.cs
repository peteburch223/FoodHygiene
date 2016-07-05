using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfinityWorks_TechTest.Helpers;

namespace InfinityWorks_TechTest.Models
{
    public interface IRatingPercentageSummary
    {
        List<RatingPercentage> ratingPercentageSummary { get; set; }
        void getRatingPercentageSummary(Int32 localAuthorityId);
    }

    public class RatingPercentageSummary : IRatingPercentageSummary
    {
        private IRatings ratings;
        private IEstablishments establishments;
        public List<RatingPercentage> ratingPercentageSummary { get; set; }

        public RatingPercentageSummary(IRatings ratings, IEstablishments establishments)
        {
            this.ratings = ratings;
            this.establishments = establishments;
        }

        public void getRatingPercentageSummary(Int32 localAuthorityId)
        {

            this.establishments.getAllByAuthorityID(localAuthorityId);
            List<String> ratings = this.ratings.getAll();

            ratingPercentageSummary = new List<RatingPercentage>();
            foreach (String rating in ratings)
            {
                ratingPercentageSummary.Add(new RatingPercentage(rating, getEstablishmentFractionByRating(rating)));
            }
        }

        private double getEstablishmentCountByRating(String rating)
        {
            return this.establishments.establishments.Where(x => x.RatingValue == rating).ToList().Count;
        }

        private double getEstablishmentFractionByRating(String rating)
        {
            return getEstablishmentCountByRating(rating) / this.establishments.count;
        }
    }

    public interface IRatingPercentage
    {
        String name { get; set; }
        double value { get; set; }
    }

    public class RatingPercentage : IRatingPercentage
    {
        public String name { get; set; }
        public double value { get; set; }

        public RatingPercentage(String name, double value)
        {
            this.name = name;
            this.value = value;
        }
    }
}