using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net.Http;
using InfinityWorks_TechTest.Helpers;

namespace InfinityWorks_TechTest.Controllers
{
    public class EstablishmentController : Controller
    {
        private FoodHygieneRatingRESTService establishmentsApiService = new FoodHygieneRatingRESTService(new HttpClient());
        private FoodHygieneRatingRESTService ratingsApiService = new FoodHygieneRatingRESTService(new HttpClient());

        // GET: Establishment
        public ActionResult RatingSummary(String id)
        {
            Ratings ratings = new Ratings(ratingsApiService);
            Establishments establishments = new Establishments(Int16.Parse(id), establishmentsApiService, ratings);
            return View(establishments.getRatingSummary());
        }
    }
}