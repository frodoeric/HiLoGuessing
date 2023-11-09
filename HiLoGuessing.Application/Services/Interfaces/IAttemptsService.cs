using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoGuessing.Application.Services.Interfaces
{
    public interface IAttemptsService
    {
        List<int> GetAttempts();
        void IncrementAttempts();
        void SaveAttempts();
        void ResetAttempts();
    }
}
