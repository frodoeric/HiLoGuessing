using HiloGuessing.Domain.Entities;

namespace HiLoGuessing.Application.Services.Interfaces
{
    public interface IComparisonService
    {
        Task<GuessResponse<HiLoGuess>> CompareNumber(Guid hiloId, int mysteryNumber, int numberGuess);
    }
}
