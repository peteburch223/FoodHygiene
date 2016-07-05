using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Mvc;
using InfinityWorks_TechTest;
using InfinityWorks_TechTest.Controllers;
using System.Threading.Tasks;

namespace InfinityWorks_TechTest.Tests.Controllers
{
    [TestFixture]
    public class EstablishmentControllerTest
    {
        [Test]
        public void FetchEstablishments()
        {
            // Arrange
            EstablishmentController controller = new EstablishmentController();

            // Act
            ViewResult result = controller.RatingSummary("23") as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
