using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiLoGuessing.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HiloController : ControllerBase
    {
        private MysteryNumberGenerator _mysteryNumber;
        private CompareMysteryNumber _compareNumber;

        public HiloController()
        {            
        }

        [HttpGet(Name = "Generate Mystery Number")]
        public IActionResult GetNumber([FromQuery] int max = 10, [FromQuery] int min = 1)
        {
            _mysteryNumber = new MysteryNumberGenerator();
            _mysteryNumber.GenerateNumber(max, min);
            var mysteryNumber = MysteryNumberRepository.GetMysteryNumber();
            return Ok(mysteryNumber);
        }

        [HttpPost(Name = "Proposes a number")]
        public IActionResult SendNumber([FromQuery] int number)
        {
            _compareNumber = new CompareMysteryNumber();
            var mysteryNumber = MysteryNumberRepository.GetMysteryNumber();
            var response = _compareNumber.CompareNumber(mysteryNumber, number);

            return Ok(response);
        }
    }

    public sealed class MysteryNumberGenerator
    {
        public void GenerateNumber(int max, int min)
        {
            var random = new Random();
            MysteryNumberRepository.SetMysteryNumber(random.Next(min, max));
        }
    }

    public sealed class CompareMysteryNumber
    {
        public GuessResponse CompareNumber(int mysteryNumber, int numberGuess)
        {
            var response = new GuessResponse();

            if (mysteryNumber == numberGuess)
            {
                response.GuessResult = GuessResult.Equal;
                response.Message = "Mystery Number Discovered!";
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

    public enum GuessResult
    {
        Greater = 1,
        Smaller = -1,
        Equal = 0
    }

    public static class MysteryNumberRepository
    {
        private static int _mysteryNumber;

        public static int GetMysteryNumber()
        {
            return _mysteryNumber;
        }

        public static void SetMysteryNumber(int mysteryNumber)
        {
            _mysteryNumber = mysteryNumber;
        }
    }

    public sealed class GuessResponse
    {
        public GuessResult GuessResult { get; set; }
        public string Message { get; set; }
    }
}
