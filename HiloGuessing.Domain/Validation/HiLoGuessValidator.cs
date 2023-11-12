using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HiloGuessing.Domain.Entities;

namespace HiloGuessing.Domain.Validation
{
    internal class HiLoGuessValidator : AbstractValidator<HiLoGuess>
    {
        public HiLoGuessValidator()
        {
            RuleFor(u => u.GeneratedMysteryNumber).NotNull().NotEmpty().GreaterThan(100);
        }
    }
}
