using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoGuessing.Application.Requests
{
    public sealed class SendNumberRequest
    {
        public Guid HiLoGuessId { get; set; }
        public int Number { get; set; }
    }
}
