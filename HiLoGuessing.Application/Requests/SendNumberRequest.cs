using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoGuessing.Application.Requests
{
    public sealed class SendNumberRequest
    {
        public Guid HiloId { get; set; }
        public Guid AttemptsId { get; set; }
        public int Number { get; set; }
    }
}
