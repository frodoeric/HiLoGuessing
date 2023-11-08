using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiloGuessing.Domain.Entities;

namespace HiloGuessing.Domain.Interfaces
{
    public interface IScoreRepository
    {
        Task<Score> GetByIdAsync(int id);
    }
}
