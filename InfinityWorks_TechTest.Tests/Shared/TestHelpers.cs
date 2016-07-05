using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Moq;
using InfinityWorks_TechTest.Helpers;
using InfinityWorks_TechTest.Models;
namespace InfinityWorks_TechTest.Tests.Shared
{
    class TestHelpers
    {
        public List<String> prepareExpectedRatingList()
        {
            List<String> expectedRatingList = new List<String>
                { "5", "4", "3", "2", "1", "0", "Pass",
                "Improvement Required", "Awaiting Publication", "Awaiting Inspection", "Exempt" };
            return expectedRatingList;
        }

        public String getJsonFromFile(String filename)
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return File.ReadAllText(dir + filename);
        }

        public Mock<IFoodHygieneRESTService> createMockApiService(String endPoint, String jsonData)
        {
            Mock<IFoodHygieneRESTService> mockService = new Mock<IFoodHygieneRESTService>();
            mockService.Setup(t => t.getAPIData(endPoint)).Returns(jsonData);
            return mockService;
        }

        public Mock<IRatings> createMockRatings()
        {
            Mock<IRatings> mockRatings = new Mock<IRatings>();
            mockRatings.Setup(t => t.getAll()).Returns(prepareExpectedRatingList());
            return mockRatings;
        }

        public Mock<IEstablishments> createMockEstablishments()
        {
            Int16 localAuthorityId = 27;
            Mock<IEstablishments> mockEstablishments = new Mock<IEstablishments>();
            mockEstablishments.Setup(t => t.getAllByAuthorityID(localAuthorityId));
            return mockEstablishments;
        }

        public Mock<IAuthorities> createMockAuthorities()
        {
            List<Authority> mockAuthoritiesList = new List<Authority>();

            for (int k = 0; k < 10; k++)
            {
                Authority mockAuthority = new Authority();
                mockAuthority.LocalAuthorityId = k;
                mockAuthority.Name = $"Name{k}";
                mockAuthoritiesList.Add(mockAuthority);
            };

            Mock<IAuthorities> mockAuthorities = new Mock<IAuthorities>();
            mockAuthorities.Setup(t => t.authorities).Returns(mockAuthoritiesList);
            mockAuthorities.Setup(t => t.getAll());
            return mockAuthorities;
        }

        public Mock<IRatingPercentageSummary> createMockRatingPercentageSummary()
        {
            List<RatingPercentage> mockRatingPercentageSummary = new List<RatingPercentage>();

            for (int k = 0; k < 10; k++)
            {
                RatingPercentage mockRatingPercentage = new RatingPercentage($"{k}", k * 0.1);
                mockRatingPercentageSummary.Add(mockRatingPercentage);
            };

            Mock<IRatingPercentageSummary> mockRPS = new Mock<IRatingPercentageSummary>();
            mockRPS.Setup(t => t.ratingPercentageSummary).Returns(mockRatingPercentageSummary);
            return mockRPS;
        }
    }
}
