using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfinityWorks_TechTest.Models;

namespace InfinityWorks_TechTest.ViewModels
{
    public interface IRatingPercentageSummaryViewModel
    {
        List<KeyValuePair<String, String>> presentRatingPercentageSummary(Int16 localAuthorityId);
    }

    public class RatingPercentageSummaryViewModel : IRatingPercentageSummaryViewModel
    {

        private IRatingPercentageSummary ratingPercentageSummary;

        private static readonly List<String> ratingsToDisplay = new List<String>
            { "5", "4", "3", "2", "1", "Exempt"};

        public RatingPercentageSummaryViewModel(IRatingPercentageSummary ratingPercentageSummary)
        {
            this.ratingPercentageSummary = ratingPercentageSummary;
        }

        public List<KeyValuePair<String, String>> presentRatingPercentageSummary (Int16 localAuthorityId)
        {
            this.ratingPercentageSummary.getRatingPercentageSummary(localAuthorityId);
            List<RatingPercentage> ratingPercentageSummary = this.ratingPercentageSummary.ratingPercentageSummary;
            ratingPercentageSummary.RemoveAll(item => !ratingsToDisplay.Contains(item.name));

            List<KeyValuePair<String, String>> result = new List<KeyValuePair<String, String>>();
            foreach (RatingPercentage ratingPercentage in ratingPercentageSummary)
            {
                result.Add(new KeyValuePair<String, String>(ratingPercentage.name, formatPercent(ratingPercentage.value)));
            }
            return result;
        }

        private String formatPercent(double ratingValue)
        {
            return ratingValue.ToString("P", CultureInfo.CurrentCulture);
        }
    }
}