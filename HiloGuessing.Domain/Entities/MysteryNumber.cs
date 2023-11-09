using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoGuessing.Infrastructure
{
    public class MysteryNumber
    {
        public MysteryNumber()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
        public int GeneratedMysteryNumber { get; set; }
        public int NumberOfAttempts { get; set; } = 1;
        public List<int> AttemptsList { get; set; } = new();
    }
}
