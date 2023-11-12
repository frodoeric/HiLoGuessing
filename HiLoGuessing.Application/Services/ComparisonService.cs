using HiloGuessing.Domain.Entities;
using HiLoGuessing.Application.Services.Interfaces;

namespace HiLoGuessing.Application.Services
{
    public class ComparisonService : IComparisonService
    {
        private IHiLoGuessService _hiLoGuessService;

        public ComparisonService(IHiLoGuessService hiLoGuessService)
        {
            _hiLoGuessService = hiLoGuessService;
        }

        public async Task<GuessResponse<HiLoGuess>> CompareNumber(
            Guid hiloId, int mysteryNumber, int numberGuess)
        {
            var response = new GuessResponse<HiLoGuess>();
            var hiloGuess = await _hiLoGuessService.GetHiLoGuessAsync(hiloId);

            if (mysteryNumber == 0)
            {
                response.GuessResult = GuessResult.NotGenerated;
                response.Message = "Please Generate a new Mystery Number";
                return response;
            }

            if (mysteryNumber == numberGuess)
            {
                response.GuessResult = GuessResult.Equal;
                response.Message = "Mystery Number Discovered!";
                hiloGuess.GeneratedMysteryNumber = 0;
                response.Data = hiloGuess;
                await _hiLoGuessService.ResetHiLoGuessAsync(hiloId);

                return response;
            }

            if (mysteryNumber > numberGuess)
            {
                
                response.GuessResult = GuessResult.Greater;
                response.Message = "Mystery Number is Greater than the Player's guess!";
                response.Data = hiloGuess;
                return response;
            }

            hiloGuess = await _hiLoGuessService.GetHiLoGuessAsync(hiloId);
            response.GuessResult = GuessResult.Smaller;
            response.Message = "Mystery Number is Smaller than the Player's guess!";
            response.Data = hiloGuess;

            return response;
        }
    }
}
