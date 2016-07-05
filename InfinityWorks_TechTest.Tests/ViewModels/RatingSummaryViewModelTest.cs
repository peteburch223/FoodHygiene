using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using InfinityWorks_TechTest.Tests.Shared;
using InfinityWorks_TechTest.Models;
using InfinityWorks_TechTest.ViewModels;

namespace InfinityWorks_TechTest.Tests.ViewModels
{
    [TestFixture]
    public class RatingSummaryViewModelTest
    {
        private TestHelpers helpers;
        private Mock<IRatingPercentageSummary> mockRatingPercentageSummary;
        private Int16 localAuthorityId;

        public RatingSummaryViewModelTest()
        {
            localAuthorityId = 27;
            helpers = new TestHelpers();
            mockRatingPercentageSummary = helpers.createMockRatingPercentageSummary();
        }

        [Test]
        public void ShouldMakeRatingSummaryPresentable()
        {
            // Arrange
            RatingPercentageSummaryViewModel ratingPercentageSummaryViewModel = new RatingPercentageSummaryViewModel(mockRatingPercentageSummary.Object);

            // Act
            List<KeyValuePair<String, String>> actualRatingPercentageSummary = ratingPercentageSummaryViewModel.presentRatingPercentageSummary(localAuthorityId);

            // Assert
            Assert.AreEqual(5, actualRatingPercentageSummary.Count);

        }
    }
}
