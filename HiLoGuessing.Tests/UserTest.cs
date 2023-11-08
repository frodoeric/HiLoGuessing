using FluentAssertions;
using HiloGuessing.Domain.Entities;
using HiloGuessing.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoGuessing.Tests
{
    internal class UserTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateUser_WithValidName()
        {
            Action action = () => new User(1, "John");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Test]
        public void CreateUser_WithEmptName()
        {
            Action action = () => new User(1, "");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
    }
}
