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
    public class AuthoritiesTest
    {
        private String endPoint;
        private TestHelpers helpers;
        private String jsonData;
        private Mock<IFoodHygieneRESTService> mockService;

        public AuthoritiesTest()
        {
            endPoint = "Authorities";
            helpers = new TestHelpers();
            jsonData = helpers.getJsonFromFile("\\Helpers\\authoritiesJson.txt");
            mockService = helpers.createMockApiService(endPoint, jsonData);
        }

        [Test]
        public void ShouldFetchAuthoritiesFromAPI()
        {
            // Arrange
            Authorities actualAuthorities = new Authorities(mockService.Object);

            // Act
            actualAuthorities.getAll();

            // Assert
            Assert.AreEqual(actualAuthorities.authorities.Count, 392);
        }
    }
}
