using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiloGuessing.Domain.Validation;

namespace HiloGuessing.Domain.Entities
{
    public sealed class Score
    {
        public int Id { get; set; }
        public int Points { get; private set; }

        public Score(int points, int id)
        {
            Points = points;
            Id = id;
        }

        private void ValidateDomain(string? points)
        {
            DomainExceptionValidation.When(points == null, "Invalid points.Points is required");
        }
    }
}
