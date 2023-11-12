using FluentAssertions;
using HiloGuessing.Domain.Entities;
using HiloGuessing.Domain.Validation;

namespace HiLoGuessing.Tests.Domain.Entities
{
    public class HiLoGuessingTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateScore_WithValidPoints()
        {
            Action action = () => new HiLoGuess();
            action.Should().NotThrow<DomainExceptionValidation>();
        }
    }
}