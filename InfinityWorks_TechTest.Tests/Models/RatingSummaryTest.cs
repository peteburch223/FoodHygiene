using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Net.Http;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using Moq;
using InfinityWorks_TechTest.Tests.Shared;
using InfinityWorks_TechTest.Helpers;
using InfinityWorks_TechTest.Models;

namespace InfinityWorks_TechTest.Tests.Models
{
    [TestFixture]
    public class RatingSummaryTest
    {
        private Int16 localAuthorityId;
        private String endPoint;
        private TestHelpers helpers;
        private String jsonData;
        private Mock<IFoodHygieneRESTService> mockService;
        private Mock<IRatings> mockRatings;

        public RatingSummaryTest()
        {
            localAuthorityId = 27;
            endPoint = $"Establishments?localAuthorityId={localAuthorityId}";
            helpers = new TestHelpers();
            jsonData = helpers.getJsonFromFile("\\Helpers\\establishmentJson.txt");
            mockService = helpers.createMockApiService(endPoint, jsonData);
            mockRatings = helpers.createMockRatings();
        }

        [Test]
        public void ShouldSummariseRatings()
        {
            // Arrange
            Establishments establishments = new Establishments(mockService.Object); // ideally need to mock this somehow
            RatingPercentageSummary ratingSummary = new RatingPercentageSummary(mockRatings.Object, establishments);

            // Act
            ratingSummary.getRatingPercentageSummary(localAuthorityId);

            // Assert
            Assert.AreEqual(ratingSummary.ratingPercentageSummary.Count, 11);
        }
    }
}
