using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoGuessing.Application.Services.Interfaces
{
    public interface IMysteryNumberService
    {
        Task<Guid> CreateHiLoGuessAsync();
        Task<int> CreateMysteryNumberAsync(Guid id, int max, int min);
        Task<int> GetMysteryNumberAsync(Guid id);
        Task<Guid> ResetHiLoGuessAsync();
    }
}
