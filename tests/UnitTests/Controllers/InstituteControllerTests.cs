using Academia.Core.Entities;
using Academia.Core.Interfaces;
using Academia.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Builders;
using Xunit;

namespace UnitTests.Controllers
{
    public class InstituteControllerTests
    {

        [Fact]
        public async Task ShouldNotCreateInstituteIfNull()
        {
            // Arrange
            var mockRepo = new Mock<IAsyncRepository<Institute>>();
            var controller = new InstituteController(mockRepo.Object);
            Institute institute = null;

            // Act
            var result = await controller.Create(institute);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task ShouldCreateInstituteIfNotNull()
        {
            // Arrange
            var mockRepo = new Mock<IAsyncRepository<Institute>>();
            var controller = new InstituteController(mockRepo.Object);
            var institute = new InstituteBuilder().Build();
            // Act
            var result = await controller.Create(institute);

            // Assert
            var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result);
            Assert.Equal("GetInstitute", createdAtRouteResult.RouteName);
            Assert.IsType<Institute>(createdAtRouteResult.Value);
        }
    }
}
