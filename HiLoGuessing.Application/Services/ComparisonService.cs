﻿using HiloGuessing.Domain.Entities;
using HiLoGuessing.Application.Services.Interfaces;

namespace HiLoGuessing.Application.Services
{
    public class ComparisonService : IComparisonService
    {
        private IMysteryNumberService _mysteryNumberService;
        private IAttemptsService _attemptsService;

        public ComparisonService(IMysteryNumberService mysteryNumberService, IAttemptsService attemptsService)
        {
            _mysteryNumberService = mysteryNumberService;
            _attemptsService = attemptsService;
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
                _mysteryNumberService.ResetMysteryNumber();

                response.GuessResult = GuessResult.Equal;
                response.Message = "Mystery Number Discovered!";

                //todo: implement MediatoR, send notification
                _attemptsService.SaveAttempts();
                _attemptsService.ResetAttempts();

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
