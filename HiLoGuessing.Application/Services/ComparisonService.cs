using HiloGuessing.Domain.Entities;
using HiLoGuessing.Application.Services.Interfaces;

namespace HiLoGuessing.Application.Services
{
    public class ComparisonService : IComparisonService
    {
        private readonly IHiLoGuessService _hiLoGuessService;

        public ComparisonService(IHiLoGuessService hiLoGuessService)
        {
            _hiLoGuessService = hiLoGuessService;
        }

        public async Task<GuessResponse<HiLoGuess>> CompareNumber(
            Guid hiloId, int mysteryNumber, int numberGuess)
        {
            var response = new GuessResponse<HiLoGuess>();

            if (!IsValidGuess(mysteryNumber))
            {
                return GetNotGeneratedResponse(response);
            }

            var hiloGuess = await _hiLoGuessService.GetHiLoGuessAsync(hiloId);

            if (IsCorrectGuess(mysteryNumber, numberGuess))
            {
                return await GetCorrectGuessResponse(response, hiloGuess, hiloId);
            }

            return GetComparisonResponse(response, hiloGuess, mysteryNumber, numberGuess);
        }

        private static bool IsValidGuess(int mysteryNumber)
        {
            return mysteryNumber != 0;
        }

        private static bool IsCorrectGuess(int mysteryNumber, int numberGuess)
        {
            return mysteryNumber == numberGuess;
        }

        private static GuessResponse<HiLoGuess> GetNotGeneratedResponse(GuessResponse<HiLoGuess> response)
        {
            response.GuessResult = GuessResult.NotGenerated;
            response.Message = "Please Generate a new Mystery Number";
            return response;
        }

        private async Task <GuessResponse<HiLoGuess>> GetCorrectGuessResponse(
            GuessResponse<HiLoGuess> response, HiLoGuess hiloGuess, Guid hiloId)
        {
            response.GuessResult = GuessResult.Equal;
            response.Message = "Mystery Number Discovered!";
            hiloGuess.GeneratedMysteryNumber = 0;
            response.Data = hiloGuess;
            await _hiLoGuessService.ResetHiLoGuessAsync(hiloId);
            return response;
        }

        private GuessResponse<HiLoGuess> GetComparisonResponse(
            GuessResponse<HiLoGuess> response, HiLoGuess hiloGuess, int mysteryNumber, int numberGuess)
        {
            if (mysteryNumber > numberGuess)
            {
                return GetGreaterResponse(response, hiloGuess);
            }

            return GetSmallerResponse(response, hiloGuess);
        }

        private GuessResponse<HiLoGuess> GetGreaterResponse(
            GuessResponse<HiLoGuess> response, HiLoGuess hiloGuess)
        {
            response.GuessResult = GuessResult.Greater;
            response.Message = "Mystery Number is Greater than the Player's guess!";
            response.Data = hiloGuess;
            return response;
        }

        private GuessResponse<HiLoGuess> GetSmallerResponse(
            GuessResponse<HiLoGuess> response, HiLoGuess hiloGuess)
        {
            response.GuessResult = GuessResult.Smaller;
            response.Message = "Mystery Number is Smaller than the Player's guess!";
            response.Data = hiloGuess;
            return response;
        }
    }

}
