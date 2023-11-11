using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiloGuessing.Domain.Entities;

namespace HiLoGuessing.Application.Services.Interfaces
{
    public interface IAttemptsService
    {
        Task<List<Attempts>> GetAttempts();
        Task IncrementAttempts(Guid id);
    }
}
