using HiLoGuessing.Application.Services;
using HiLoGuessing.Application.Services.Interfaces;
using HiloGuessing.Domain.Entities;
using HiloGuessing.Domain.Interfaces;
using Moq;

namespace HiLoGuessing.Tests.Application.Services
{
    [TestFixture]
    public class AttemptsServiceTests
    {
        private IAttemptsService _attemptsService;
        private Mock<IRepository<Attempts>> _attemptRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _attemptRepositoryMock = new Mock<IRepository<Attempts>>();
            _attemptsService = new AttemptsService(_attemptRepositoryMock.Object);
        }

        [Test]
        public async Task GetAttempts_ShouldReturnAllAttempts()
        {
            // Arrange
            var attempts = new List<Attempts> { new Attempts(), new Attempts() };
            _attemptRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(attempts);

            // Act
            var result = await _attemptsService.GetAttempts();

            // Assert
            Assert.That(result, Is.EqualTo(attempts));
        }

        [Test]
        public async Task IncrementAttempts_ShouldIncrementNumberOfAttempts()
        {
            // Arrange
            var attemptId = Guid.NewGuid();
            var attempt = new Attempts { AttemptsId = attemptId, NumberOfAttempts = 5 };
            _attemptRepositoryMock.Setup(x => x.GetByIdAsync(attemptId)).ReturnsAsync(attempt);

            // Act
            await _attemptsService.IncrementAttempts(attemptId);

            // Assert
            Assert.That(attempt.NumberOfAttempts, Is.EqualTo(6));
            _attemptRepositoryMock.Verify(x => x.UpdateAsync(attempt), Times.Once);
        }
    }
}