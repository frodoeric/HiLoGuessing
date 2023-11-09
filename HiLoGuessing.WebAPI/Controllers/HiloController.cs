using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiLoGuessing.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HiloController : ControllerBase
    {

        [HttpGet("MysteryNumber")]
        public IActionResult GetNumber([FromQuery] int max = 10, [FromQuery] int min = 1)
        {
            new MysteryNumberGenerator().GenerateNumber(max, min);
            var result = MysteryNumberRepository.MysteryNumber;
            return Ok(result);
        }

        [HttpGet("Attempts")]
        public IActionResult GetAttempts()
        {
            var result = MysteryNumberRepository.AttemptsList;
            return Ok(result);
        }

        [HttpPost("MysteryNumber")]
        public IActionResult SendNumber([FromQuery] int number)
        {
            var mysteryNumber = MysteryNumberRepository.MysteryNumber;
            var response = new CompareMysteryNumber().CompareNumber(mysteryNumber, number);

            if (response.GuessResult == GuessResult.NotGenerated)
            {
                return BadRequest(response);
            }

            new AttemptsService().AttemptsSum();

            return Ok(response);
        }
    }

    public sealed class MysteryNumberGenerator
    {
        public void GenerateNumber(int max, int min)
        {
            var random = new Random();
            MysteryNumberRepository.MysteryNumber = (random.Next(min, max));
        }

        public void ResetMysteryNumber()
        {
            MysteryNumberRepository.MysteryNumber = 0;
        }
    }

    public sealed class CompareMysteryNumber
    {
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
                new MysteryNumberGenerator().ResetMysteryNumber();

                response.GuessResult = GuessResult.Equal;
                response.Message = "Mystery Number Discovered!";

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

    public sealed class AttemptsService
    {
        public void AttemptsSum()
        {
            MysteryNumberRepository.NumberOfAttempts++;
        }

        public void ResetAttempts()
        {
            MysteryNumberRepository.NumberOfAttempts = 0;
        }

        public void SaveAttempts()
        {
            MysteryNumberRepository.AttemptsList.Add(MysteryNumberRepository.NumberOfAttempts);
        }
    }

    public enum GuessResult
    {
        NotGenerated = 0,
        Equal = 1,
        Smaller = 2,
        Greater = 3,
    }

    public static class MysteryNumberRepository
    {
        public static int MysteryNumber { get; set; }
        public static int NumberOfAttempts { get; set; }
        public static List<int> AttemptsList { get; set; } = new();
    }

    public sealed class GuessResponse
    {
        public GuessResult GuessResult { get; set; }
        public string Message { get; set; }
    }
}
