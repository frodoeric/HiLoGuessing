using HiloGuessing.Domain.Entities;
using HiLoGuessing.Application.Services.Interfaces;

namespace HiLoGuessing.Application.Services
{
    public class ComparisonService : IComparisonService
    {
        private IMysteryNumberService _mysteryNumberService;

        public ComparisonService(IMysteryNumberService mysteryNumberService)
        {
            _mysteryNumberService = mysteryNumberService;
        }

        public GuessResponse CompareNumber(int mysteryNumber, int numberGuess)
        {
            var response = new GuessResponse();

            if (mysteryNumber == 0)
            {
                response.GuessResult = GuessResult.NotGenerated;
                response.Message = "Please Generate a new Mystery Number";
                return response;
            }

            if (mysteryNumber == numberGuess)
            {
                var attempts = new AttemptsService();
                _mysteryNumberService.ResetMysteryNumber();

                response.GuessResult = GuessResult.Equal;
                response.Message = "Mystery Number Discovered!";

                //todo: implement MediatoR, send notification
                attempts.SaveAttempts();
                attempts.ResetAttempts();

                return response;
            }

            if (mysteryNumber > numberGuess)
            {
                response.GuessResult = GuessResult.Greater;
                response.Message = "Mystery Number is Greater than the Player's guess!";
                return response;
            }

            response.GuessResult = GuessResult.Smaller;
            response.Message = "Mystery Number is Smaller than the Player's guess!";

            return response;
        }
    }
}
