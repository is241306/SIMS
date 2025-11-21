using api.DTOs.Incident;
using api.Models;
using api.Repositories;
using api.Services;
using Moq;
using Xunit;

namespace api.Tests.Services
{
    public class IncidentServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsIncidents()
        {
            // Arrange
            var mockIncidentRepo = new Mock<IIncidentRepository>();
            var mockAlertRepo = new Mock<IAlertRepository>();
            var incidents = new List<Incident>
            {
                new Incident { Id = 1, Description = "Test Incident" }
            };
            mockIncidentRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(incidents);
            var service = new IncidentService(mockIncidentRepo.Object, mockAlertRepo.Object);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsIncident()
        {
            // Arrange
            var mockIncidentRepo = new Mock<IIncidentRepository>();
            var mockAlertRepo = new Mock<IAlertRepository>();
            var incident = new Incident { Id = 1, Description = "Test" };
            mockIncidentRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(incident);
            var service = new IncidentService(mockIncidentRepo.Object, mockAlertRepo.Object);

            // Act
            var result = await service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task UpdateStatusAsync_UpdatesStatus()
        {
            // Arrange
            var mockIncidentRepo = new Mock<IIncidentRepository>();
            var mockAlertRepo = new Mock<IAlertRepository>();
            var incident = new Incident { Id = 1, Status = IncidentStatus.Open };
            mockIncidentRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(incident);
            var service = new IncidentService(mockIncidentRepo.Object, mockAlertRepo.Object);

            // Act
            var result = await service.UpdateStatusAsync(1, "Resolved");

            // Assert
            Assert.True(result);
        }
    }
}
