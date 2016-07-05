using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Net;
using System.Net.Http;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using Moq;
using InfinityWorks_TechTest.Tests.Shared;


namespace InfinityWorks_TechTest.Helpers.Tests
{
    [TestFixture]
    public class APITest
    {
        [Test]
        public void ShouldGetAPIData()

        {
            // Arrange
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            String jsonData = File.ReadAllText(dir + "\\Helpers\\authorityJson.txt");

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("http://api.ratings.food.gov.uk/Authorities")
                .Respond("application/json", jsonData);

            var client = new HttpClient(mockHttp);
            FoodHygieneRatingRESTService api = new FoodHygieneRatingRESTService(client);

            // Act
            String jsonResponse = api.getAPIData("Authorities");

            //Assert
            Assert.AreEqual(jsonData, jsonResponse);
        }

        [Test]
        public void ShouldRaiseExceptionIfAPIRespondsWithErrorCode()
        {
            // Arrange
            HttpStatusCode errorStatusCode = HttpStatusCode.BadRequest;
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("http://api.ratings.food.gov.uk/Authorities")
                .Respond(errorStatusCode);

            var client = new HttpClient(mockHttp);
            FoodHygieneRatingRESTService api = new FoodHygieneRatingRESTService(client);

            // Act

            //Assert
            Assert.That(() => api.getAPIData("Authorities"),
                Throws.Exception
                .TypeOf<AggregateException>());
        }
    }


    [TestFixture]
    public class EstablishmentTest
    {
        private Int16 localAuthorityId;
        private String endPoint;
        private TestHelpers helpers;
        private String jsonData;
        private Mock<IFoodHygieneRESTService> mockService;
        private Mock<IRatings> mockRatings;

        public EstablishmentTest()
        {
            localAuthorityId = 27;
            endPoint = $"Establishments?localAuthorityId={localAuthorityId}";
            helpers = new TestHelpers();
            jsonData = helpers.getJsonFromFile("\\Helpers\\establishmentJson.txt");
            mockService = helpers.createMockApiService(endPoint, jsonData);
            mockRatings = helpers.createMockRatings();
        }

        [Test]
        public void ShouldFetchEstablishmentsFromAPI()
        {
            // Arrange
            Establishments establishments = new Establishments(mockService.Object);

            // Act
            establishments.getAllByAuthorityID(localAuthorityId);

            // Assert
            Assert.AreEqual(establishments.establishments.Count, 4);
        }
    }

    [TestFixture]
    public class RatingsTest
    {
        private String endPoint;
        private TestHelpers helpers;
        private String jsonData;
        private Mock<IFoodHygieneRESTService> mockService;

        public RatingsTest()
        {
            endPoint = "Ratings";
            helpers = new TestHelpers();
            jsonData = helpers.getJsonFromFile("\\Helpers\\ratingJson.txt");
            mockService = helpers.createMockApiService(endPoint, jsonData);
        }

        [Test]
        public void ShouldFetchRatingsFromAPI()
        {
            // Arrange
            List<String> expectedRatingList = helpers.prepareExpectedRatingList();
            Ratings ratings = new Ratings(mockService.Object);

            // Act
            List<String> actualRatingList = ratings.getAll();

            // Assert
            CollectionAssert.AreEquivalent(expectedRatingList, actualRatingList);
        }
    }
}
