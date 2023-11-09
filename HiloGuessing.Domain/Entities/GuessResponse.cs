using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiloGuessing.Domain.Entities
{
    public sealed class GuessResponse
    {
        public GuessResult GuessResult { get; set; }
        public string Message { get; set; }
    }
}
