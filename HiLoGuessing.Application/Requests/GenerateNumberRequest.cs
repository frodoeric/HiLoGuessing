using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoGuessing.Application.Requests
{
    public sealed class GenerateNumberRequest
    {
        public Guid HiLoId { get; set; }
        public int Max { get; set; } = 10;
        public int Min { get; set; } = 1;
    }
}
