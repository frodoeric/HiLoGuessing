using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HiloGuessing.Domain.Entities
{
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
