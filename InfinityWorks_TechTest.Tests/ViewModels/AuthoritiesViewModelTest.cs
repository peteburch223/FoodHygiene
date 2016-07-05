using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Net.Http;
using NUnit.Framework;
using Moq;
using InfinityWorks_TechTest.Tests.Shared;
using InfinityWorks_TechTest.Helpers;
using InfinityWorks_TechTest.Models;
using InfinityWorks_TechTest.ViewModels;

namespace InfinityWorks_TechTest.Tests.ViewModels
{
    [TestFixture]
    public class AuthoritiesViewModelTest
    {
        private TestHelpers helpers;
        private Mock<IAuthorities> mockAuthorities;

        public AuthoritiesViewModelTest()
        {
            helpers = new TestHelpers();
            mockAuthorities = helpers.createMockAuthorities();
        } 
         
        [Test]
        public void ShouldCreateADictionaryFromAuthorities()
        {
            // Arrange
            AuthoritiesViewModel authoritiesViewModel = new AuthoritiesViewModel(mockAuthorities.Object);

            // Act
            authoritiesViewModel.presentAuthorities();

            // Assert
            mockAuthorities.Verify(t => t.getAll());
            mockAuthorities.Verify(t => t.authorities);
            Assert.AreEqual(authoritiesViewModel.authoritiesDict.Count, 10);
        }
    }
}
