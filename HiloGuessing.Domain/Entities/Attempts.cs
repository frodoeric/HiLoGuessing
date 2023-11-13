using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HiloGuessing.Domain.Entities
{
    public class Attempts
    {
        [Key]
        public Guid AttemptsId { get; set; }

        public int NumberOfAttempts { get; set; } = 0;

        [JsonIgnore]
        public Guid HiLoGuessId { get; set; }

        [JsonIgnore]
        public HiLoGuess HiLoGuess { get; set; }
    }
}
