using HiloGuessing.Domain.Entities;
using HiLoGuessing.Infrastructure;

namespace HiLoGuessing.Application.Services.Interfaces
{
    public interface IComparisonService
    {
        Task<GuessResponse<HiLoGuess>> CompareNumber(int mysteryNumber, int numberGuess);
    }
}
