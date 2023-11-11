using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HiloGuessing.Domain.Entities
{
    public class HiLoGuess
    {
        [Key]
        public Guid HiLoGuessId { get; set; }
        public int GeneratedMysteryNumber { get; set; } = 0;
        
        public Attempts Attempts { get; set; }
    }

    public class Attempts
    {
        [Key]
        public Guid AttemptsId { get; set; }

        public int NumberOfAttempts { get; set; } = 1;

        [JsonIgnore]
        public Guid HiLoGuessId { get; set; }

        [JsonIgnore]
        public HiLoGuess HiLoGuess { get; set; }
    }

}
