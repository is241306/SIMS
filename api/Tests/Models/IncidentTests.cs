using api.Models;
using Xunit;

namespace api.Tests.Models
{
    public class IncidentTests
    {
        [Fact]
        public void Incident_DefaultValues_AreSet()
        {
            // Arrange & Act
            var incident = new Incident();

            // Assert
            Assert.Equal(IncidentStatus.Open, incident.Status);
            Assert.Equal(IncidentSeverity.Low, incident.Severity);
            Assert.Equal(string.Empty, incident.Description);
        }

        [Fact]
        public void Incident_CanSetProperties()
        {
            // Arrange & Act
            var incident = new Incident
            {
                Id = 1,
                Description = "Security breach",
                Status = IncidentStatus.Escalated,
                Severity = IncidentSeverity.Critical,
                AssignedUserId = 5
            };

            // Assert
            Assert.Equal(1, incident.Id);
            Assert.Equal("Security breach", incident.Description);
            Assert.Equal(IncidentStatus.Escalated, incident.Status);
            Assert.Equal(IncidentSeverity.Critical, incident.Severity);
            Assert.Equal(5, incident.AssignedUserId);
        }
    }
}
