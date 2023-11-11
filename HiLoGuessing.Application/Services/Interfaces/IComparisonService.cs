using HiloGuessing.Domain.Entities;

namespace HiLoGuessing.Application.Services.Interfaces
{
    public interface IComparisonService
    {
        Task<GuessResponse<HiLoGuess>> CompareNumber(int mysteryNumber, int numberGuess);
    }
}
