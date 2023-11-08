using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HiloGuessing.Domain.Entities;

namespace HiloGuessing.Domain.Validation
{
    internal class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name).NotNull().NotEmpty().GreaterThan("3");
        }
    }
}
