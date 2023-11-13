using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HiloGuessing.Domain.Entities
{
    public class Game
    {
        [Key]
        public Guid GameId { get; set; }
        public Guid CurrentPlayerID { get; set; }

        public List<HiLoGuess> HiLoGuess { get; set; }
    }

    public class HiLoGuess
    {
        [Key]
        public Guid HiLoGuessId { get; set; }
        public int GeneratedMysteryNumber { get; set; } = 0;

        [JsonIgnore]
        public Guid GameId { get; set; }

        public Attempts Attempts { get; set; }
        public Player Player { get; set; }
    }

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

    public class Player
    {
        [Key]
        public Guid PlayerId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public Guid HiLoGuessId { get; set; }

        [JsonIgnore]
        public HiLoGuess HiLoGuess { get; set; }
    }
}
