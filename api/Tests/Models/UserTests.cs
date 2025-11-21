using api.Models;
using Xunit;

namespace api.Tests.Models
{
    public class UserTests
    {
        [Fact]
        public void User_DefaultValues_AreSet()
        {
            // Arrange & Act
            var user = new User();

            // Assert
            Assert.True(user.IsActive);
            Assert.Equal(string.Empty, user.Username);
            Assert.NotNull(user.UserRoles);
            Assert.NotNull(user.AssignedIncidents);
        }

        [Fact]
        public void User_CanSetProperties()
        {
            // Arrange & Act
            var user = new User
            {
                Id = 1,
                Username = "admin",
                PasswordHash = "hash123",
                PasswordSalt = "salt123",
                IsActive = false
            };

            // Assert
            Assert.Equal(1, user.Id);
            Assert.Equal("admin", user.Username);
            Assert.Equal("hash123", user.PasswordHash);
            Assert.Equal("salt123", user.PasswordSalt);
            Assert.False(user.IsActive);
        }
    }
}
