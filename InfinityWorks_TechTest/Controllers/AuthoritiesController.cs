using System;
using System.Web.Mvc;

using InfinityWorks_TechTest.ViewModels;

namespace InfinityWorks_TechTest.Controllers
{
    public class AuthoritiesController : Controller
    {
        private IAuthoritiesViewModel authoritiesViewModel;
        private IRatingPercentageSummaryViewModel RatingPercentageSummaryViewModel;

        public AuthoritiesController(IAuthoritiesViewModel authoritiesViewModel, 
            IRatingPercentageSummaryViewModel RatingPercentageSummaryViewModel)
        {
            this.authoritiesViewModel = authoritiesViewModel;
            this.RatingPercentageSummaryViewModel = RatingPercentageSummaryViewModel;
        }

        // GET: AuthoritiesList
        public ActionResult Index()
        {
            authoritiesViewModel.presentAuthorities();
            return View(authoritiesViewModel);
        }

        // GET: RatingPercentageSummary with parameter
        public ActionResult RatingPercentageSummary(String id)
        {
            if (String.IsNullOrEmpty(id))
                return RedirectToAction("Index", "Authorities");
            else
                return View(RatingPercentageSummaryViewModel.presentRatingPercentageSummary(Int16.Parse(id)));   
        }
    }
}
