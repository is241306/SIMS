using api.DTOs.Users;
using api.Models;
using api.Repositories;
using api.Services;
using Moq;
using Xunit;

namespace api.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsUsers()
        {
            // Arrange
            var mockUserRepo = new Mock<IUserRepository>();
            var users = new List<User>
            {
                new User { Id = 1, Username = "user1", IsActive = true }
            };
            mockUserRepo.Setup(r => r.GetAllAsync(default)).ReturnsAsync(users);
            var service = new UserService(mockUserRepo.Object);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsUser()
        {
            // Arrange
            var mockUserRepo = new Mock<IUserRepository>();
            var user = new User { Id = 1, Username = "testuser", IsActive = true };
            mockUserRepo.Setup(r => r.GetByIdAsync(1, default)).ReturnsAsync(user);
            var service = new UserService(mockUserRepo.Object);

            // Act
            var result = await service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.Username);
        }

        [Fact]
        public async Task DeleteAsync_DeletesUser()
        {
            // Arrange
            var mockUserRepo = new Mock<IUserRepository>();
            var user = new User { Id = 1, Username = "testuser", IsActive = true };
            mockUserRepo.Setup(r => r.GetByIdAsync(1, default)).ReturnsAsync(user);
            mockUserRepo.Setup(r => r.DeleteAsync(user, default)).Returns(Task.CompletedTask);
            var service = new UserService(mockUserRepo.Object);

            // Act
            var result = await service.DeleteAsync(1);

            // Assert
            Assert.True(result);
        }
    }
}
