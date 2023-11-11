using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoGuessing.Application.Requests
{
    public sealed class GenerateNumberRequest
    {
        public Guid Id { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
    }
}
