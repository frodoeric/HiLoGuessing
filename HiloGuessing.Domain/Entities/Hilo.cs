using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiloGuessing.Domain.Entities
{
    internal class Hilo
    {
        public Random? Generator { get; private set; }
        public int GeneratedNumber { get; set; }
        public int NumberOfAttempts { get; set; }


        public Hilo(Random? generator, int generatedNumber, int numberOfAttempts)
        {
            Generator = generator;
            GeneratedNumber = generatedNumber;
            NumberOfAttempts = numberOfAttempts;
        }

    }
}
