using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using u23637707_HW01_API.Models;
using u23637707_HW01_API.Controllers;

namespace u23637707_HW01_API.Tests
{
    public class CampusBuzzControllerTests
    {
        private AppDbContext CreateTestContext()
        {
            var dbOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var testContext = new AppDbContext(dbOptions);

            var sampleEvents = new List<Event>
            {
                new Event
                {
                    Event_Id = Guid.NewGuid(),
                    Title = "Pride Month",
                    Location = "Starting at piazza",
                    TicketPricing = 75
                }
            };

            testContext.Events.AddRange(sampleEvents);
            testContext.SaveChanges();
            return testContext;
        }

        [Fact]
        public async Task FetchAllEvents_ReturnsOkAndNotNull()
        {
            // Arrange
            var testContext = CreateTestContext();
            var repo = new Repo(testContext);
            var controller = new CampusBuzzController(repo);

            // Act
            var response = await controller.FetchAllEvents();
            var okResponse = response as OkObjectResult;

            // Assert
            Assert.NotNull(okResponse);
            Assert.Equal(200, okResponse.StatusCode);
            Assert.NotNull(okResponse.Value);
        }

        [Fact]
        public async Task FetchEventById_ReturnsOkAndNotNull()
        {
            // Arrange
            var testContext = CreateTestContext();
            var targetId = testContext.Events.First().Event_Id;
            var repo = new Repo(testContext);
            var controller = new CampusBuzzController(repo);

            // Act
            var response = await controller.FetchEventById(targetId);
            var okResponse = response as OkObjectResult;

            // Assert
            Assert.NotNull(okResponse);
            Assert.Equal(200, okResponse.StatusCode);
            Assert.NotNull(okResponse.Value);
        }
    }
}