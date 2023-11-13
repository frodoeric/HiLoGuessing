using HiloGuessing.Domain.Entities;
using HiLoGuessing.Application.Services;
using HiLoGuessing.Application.Services.Interfaces;
using Moq;
using Serilog;

namespace HiLoGuessing.Tests.Application.Services
{
    public class HiLoGuessServiceTest
    {
        [TestFixture]
        public class ComparisonServiceTests
        {
            private IComparisonService _comparisonService;
            private Mock<IHiLoGuessService> _mockHiLoGuessService;
            private Mock<ILogger> _loggerMock;

            [SetUp]
            public void Setup()
            {
                _loggerMock = new Mock<ILogger>();
                _mockHiLoGuessService = new Mock<IHiLoGuessService>();
                _comparisonService = new ComparisonService(_mockHiLoGuessService.Object, _loggerMock.Object);
                _mockHiLoGuessService.Setup(mock => mock.GetHiLoGuessAsync(It.IsAny<Guid>()))
                    .ReturnsAsync(new HiLoGuess());
            }

            [Test]
            public async Task CompareNumber_ValidGuess_ReturnsCorrectResponse()
            {
                // Arrange
                var hiloId = Guid.NewGuid();
                var mysteryNumber = 10;
                var numberGuess = 10;

                // Act
                var result = await _comparisonService.CompareNumber(hiloId, mysteryNumber, numberGuess);
                Assert.Multiple(() =>
                {

                    // Assert
                    Assert.That(result.GuessResult, Is.EqualTo(GuessResult.Equal));
                    Assert.That(result.Message, Is.EqualTo("Mystery Number Discovered!"));
                    Assert.That(result.Data.GeneratedMysteryNumber, Is.EqualTo(0));
                });
                _mockHiLoGuessService.Verify(mock => mock.ResetHiLoGuessAsync(hiloId), Times.Once);
            }

            [Test]
            public async Task CompareNumber_InvalidGuess_ReturnsNotGeneratedResponse()
            {
                // Arrange
                var hiloId = Guid.NewGuid();
                var mysteryNumber = 0;
                var numberGuess = 5;

                // Act
                var result = await _comparisonService.CompareNumber(hiloId, mysteryNumber, numberGuess);
                Assert.Multiple(() =>
                {

                    // Assert
                    Assert.That(result.GuessResult, Is.EqualTo(GuessResult.NotGenerated));
                    Assert.That(result.Message, Is.EqualTo("Please Generate a new Mystery Number"));
                    Assert.That(result.Data, Is.Null);
                });
                

                _mockHiLoGuessService.Verify(mock => mock.ResetHiLoGuessAsync(It.IsAny<Guid>()), Times.Never);
            }

            [Test]
            public async Task CompareNumber_SmallerGuess_ReturnsSmallerResponse()
            {
                // Arrange
                var hiloId = Guid.NewGuid();
                var mysteryNumber = 10;
                var numberGuess = 15;

                // Act
                var result = await _comparisonService.CompareNumber(hiloId, mysteryNumber, numberGuess);
                Assert.Multiple(() =>
                {

                    // Assert
                    Assert.That(result.GuessResult, Is.EqualTo(GuessResult.Smaller));
                    Assert.That(result.Message, Is.EqualTo("Mystery Number is Smaller than the Player's guess!"));
                    Assert.That(result.Data, Is.Not.Null);
                });
                _mockHiLoGuessService.Verify(mock => mock.ResetHiLoGuessAsync(It.IsAny<Guid>()), Times.Never);
            }

            [Test]
            public async Task CompareNumber_GreaterGuess_ReturnsGreaterResponse()
            {
                // Arrange
                var hiloId = Guid.NewGuid();
                var mysteryNumber = 15;
                var numberGuess = 10;

                // Act
                var result = await _comparisonService.CompareNumber(hiloId, mysteryNumber, numberGuess);
                Assert.Multiple(() =>
                {

                    // Assert
                    Assert.That(result.GuessResult, Is.EqualTo(GuessResult.Greater));
                    Assert.That(result.Message, Is.EqualTo("Mystery Number is Greater than the Player's guess!"));
                    Assert.That(result.Data, Is.Not.Null);
                });
                _mockHiLoGuessService.Verify(mock => mock.ResetHiLoGuessAsync(It.IsAny<Guid>()), Times.Never);
            }
        }
    }
}
