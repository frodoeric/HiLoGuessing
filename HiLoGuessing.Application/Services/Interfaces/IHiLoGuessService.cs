using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiloGuessing.Domain.Entities;

namespace HiLoGuessing.Application.Services.Interfaces
{
    public interface IHiLoGuessService
    {
        Task<HiLoGuess> CreateHiLoGuessAsync();
        Task<int> CreateMysteryNumberAsync(Guid id, int max, int min);
        Task<int> GetMysteryNumberAsync(Guid id);
        Task ResetHiLoGuessAsync(Guid id);
        Task<HiLoGuess> GetHiLoGuessAsync(Guid id);
        Task<List<HiLoGuess>> GetAllHiLoGuessesAsync();
    }
}
