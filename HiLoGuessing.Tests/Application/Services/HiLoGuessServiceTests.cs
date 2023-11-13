using HiLoGuessing.Application.Services;
using HiLoGuessing.Application.Services.Interfaces;
using HiloGuessing.Domain.Entities;
using HiloGuessing.Domain.Interfaces;
using Moq;
using Serilog;

namespace HiLoGuessing.Tests.Application.Services
{
    [TestFixture]
    public class HiLoGuessServiceTests
    {
        private IHiLoGuessService _hiLoGuessService;
        private Mock<IRepository<HiLoGuess>> _mockHiLoRepository;
        private Mock<ILogger> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger>();
            _mockHiLoRepository = new Mock<IRepository<HiLoGuess>>();
            _hiLoGuessService = new HiLoGuessService(_mockHiLoRepository.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetAllHiLoGuessesAsync_ReturnsListOfHiLoGuesses()
        {
            // Arrange
            var expectedHiLoGuesses = new List<HiLoGuess>
            {
                new HiLoGuess(),
                new HiLoGuess(),
                new HiLoGuess()
            };

            _mockHiLoRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expectedHiLoGuesses);

            // Act
            var result = await _hiLoGuessService.GetAllHiLoGuessesAsync();

            // Assert
            Assert.That(result, Is.EqualTo(expectedHiLoGuesses));
        }

        [Test]
        public async Task CreateHiLoGuessAsync_ReturnsNewHiLoGuessWithAttempts()
        {
            // Arrange
            var expectedHiLoGuess = new HiLoGuess { Attempts = new Attempts() };

            _mockHiLoRepository.Setup(repo => repo.AddAsync(It.IsAny<HiLoGuess>())).ReturnsAsync(expectedHiLoGuess);

            // Act
            var result = await _hiLoGuessService.CreateHiLoGuessAsync("John");

            // Assert
            Assert.That(result, Is.EqualTo(expectedHiLoGuess));
            _mockHiLoRepository.Verify(repo => repo.AddAsync(It.IsAny<HiLoGuess>()), Times.Once);
        }

        [Test]
        public async Task CreateMysteryNumberAsync_SetsGeneratedMysteryNumberAndUpdateRepository()
        {
            // Arrange
            var hiloId = Guid.NewGuid();
            var max = 100;
            var min = 1;

            var existingHiLoGuess = new HiLoGuess();

            _mockHiLoRepository.Setup(repo => repo.GetByIdAsync(hiloId)).ReturnsAsync(existingHiLoGuess);

            // Act
            var result = await _hiLoGuessService.CreateMysteryNumberAsync(hiloId, max, min);
            Assert.Multiple(() =>
            {

                // Assert
                Assert.That(result >= min && result < max, Is.True);
                Assert.That(existingHiLoGuess.GeneratedMysteryNumber, Is.EqualTo(result));
            });
            _mockHiLoRepository.Verify(repo => repo.UpdateAsync(existingHiLoGuess), Times.Once);
        }

        [Test]
        public async Task GetMysteryNumberAsync_ReturnsGeneratedMysteryNumber()
        {
            // Arrange
            var hiloId = Guid.NewGuid();
            var expectedMysteryNumber = 42;

            var existingHiLoGuess = new HiLoGuess { GeneratedMysteryNumber = expectedMysteryNumber };

            _mockHiLoRepository.Setup(repo => repo.GetByIdAsync(hiloId)).ReturnsAsync(existingHiLoGuess);

            // Act
            var result = await _hiLoGuessService.GetMysteryNumberAsync(hiloId);

            // Assert
            Assert.That(result, Is.EqualTo(expectedMysteryNumber));
        }

        [Test]
        public async Task ResetHiLoGuessAsync_ResetsGeneratedMysteryNumberAndUpdateRepository()
        {
            // Arrange
            var hiloId = Guid.NewGuid();

            var existingHiLoGuess = new HiLoGuess { GeneratedMysteryNumber = 42 };

            _mockHiLoRepository.Setup(repo => repo.GetByIdAsync(hiloId)).ReturnsAsync(existingHiLoGuess);

            // Act
            await _hiLoGuessService.ResetHiLoGuessAsync(hiloId);

            // Assert
            Assert.That(existingHiLoGuess.GeneratedMysteryNumber, Is.EqualTo(0));

            _mockHiLoRepository.Verify(repo => repo.UpdateAsync(existingHiLoGuess), Times.Once);
        }

        [Test]
        public async Task GetHiLoGuessAsync_ReturnsHiLoGuessById()
        {
            // Arrange
            var hiloId = Guid.NewGuid();
            var expectedHiLoGuess = new HiLoGuess { HiLoGuessId = hiloId };

            _mockHiLoRepository.Setup(repo => repo.GetByIdAsync(hiloId)).ReturnsAsync(expectedHiLoGuess);

            // Act
            var result = await _hiLoGuessService.GetHiLoGuessAsync(hiloId);

            // Assert
            Assert.That(result, Is.EqualTo(expectedHiLoGuess));
        }
    }
}
