using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoGuessing.Infrastructure
{
    public static class MysteryNumberRepository
    {
        public static int MysteryNumber { get; set; }
        public static int NumberOfAttempts { get; set; } = 1;
        public static List<int> AttemptsList { get; set; } = new();
    }
}
