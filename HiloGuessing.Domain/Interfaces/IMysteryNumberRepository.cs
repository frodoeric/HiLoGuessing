using HiloGuessing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiLoGuessing.Infrastructure;

namespace HiloGuessing.Domain.Interfaces
{
    public interface IMysteryNumberRepository
    {
        Task<MysteryNumber> CreateAsync(MysteryNumber mysteryNumber);
        Task<MysteryNumber?> GetByIdAsync(Guid id);
        Task<MysteryNumber> UpdateByIdAsync(MysteryNumber mysteryNumber);
    }
}
