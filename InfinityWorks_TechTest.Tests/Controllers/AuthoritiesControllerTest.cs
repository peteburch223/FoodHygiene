using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using System.Web.Mvc;
using InfinityWorks_TechTest;
using InfinityWorks_TechTest.Controllers;
using InfinityWorks_TechTest.ViewModels;
using System.Threading.Tasks;

namespace InfinityWorks_TechTest.Tests.Controllers
{
    [TestFixture]
    public class AuthoritiesControllerTest
    {
        private Mock<IAuthoritiesViewModel> mockAuthoritiesViewModel;
        private Mock<IRatingPercentageSummaryViewModel> mockRatingPercentageSummaryViewModel;

        public AuthoritiesControllerTest()
            {
                mockAuthoritiesViewModel = new Mock<IAuthoritiesViewModel>();
                mockRatingPercentageSummaryViewModel = new Mock<IRatingPercentageSummaryViewModel>();
            }
   
        [Test]
        public void AuthoritiesControllerIndexActionResult()
        {
            // Arrange
            AuthoritiesController controller = new AuthoritiesController(mockAuthoritiesViewModel.Object, mockRatingPercentageSummaryViewModel.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AuthoritiesControllerRatingPercentageSummaryActionResult()
        {
            // Arrange
            AuthoritiesController controller = new AuthoritiesController(mockAuthoritiesViewModel.Object, mockRatingPercentageSummaryViewModel.Object);

            // Act
            ViewResult result = controller.RatingPercentageSummary("23") as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AuthoritiesControllerRatingPercentageSummaryActionResultUndefinedParameter()
        {
            // Arrange

            AuthoritiesController controller = new AuthoritiesController(mockAuthoritiesViewModel.Object, mockRatingPercentageSummaryViewModel.Object);

            // Act
            ViewResult result = controller.RatingPercentageSummary(null) as ViewResult;

            //Assert
            Assert.IsNull(result);
        }
    }
}
