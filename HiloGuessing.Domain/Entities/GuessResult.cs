using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiloGuessing.Domain.Entities
{
    public enum GuessResult
    {
        NotGenerated = 0,
        Equal = 1,
        Smaller = 2,
        Greater = 3,
    }
}
