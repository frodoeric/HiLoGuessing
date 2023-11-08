using FluentAssertions;
using HiloGuessing.Domain.Entities;
using HiloGuessing.Domain.Validation;

namespace HiLoGuessing.Tests
{
    public class ScoreTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateScore_WithValidPoints()
        {
            Action action = () => new Score(1, 1);
            action.Should().NotThrow<DomainExceptionValidation>();
        }
    }
}