using HiloGuessing.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiloGuessing.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public User(int id, string name)
        {
            Id = id;
            ValidateDomain(name);
        }

        private void ValidateDomain(string? name)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Invalid name.Name is required");
            Name = name;
        }
    }
}
