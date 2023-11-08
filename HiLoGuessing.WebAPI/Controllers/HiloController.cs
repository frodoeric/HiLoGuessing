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
        public int GetNumber([FromQuery] int max = 10, [FromQuery] int min = 1)
        {
            _mysteryNumber = new MysteryNumberGenerator();
            _mysteryNumber.GenerateNumber(max, min);
            var mysteryNumber = MysteryNumberRepository.GetMysteryNumber();
            return mysteryNumber;
        }

        [HttpPost(Name = "Proposes a number")]
        public int SendNumber([FromQuery] int number)
        {
            _compareNumber = new CompareMysteryNumber();
            var mysteryNumber = MysteryNumberRepository.GetMysteryNumber();
            return _compareNumber.CompareNumber(mysteryNumber, number);
        }
    }

    public class MysteryNumberGenerator
    {
        public void GenerateNumber(int max, int min)
        {
            var random = new Random();
            MysteryNumberRepository.SetMysteryNumber(random.Next(min, max));
        }
    }

    public class CompareMysteryNumber
    {
        public int CompareNumber(int mysteryNumber, int numberGuess)
        {
            if (mysteryNumber == numberGuess)
            {
                return 0;
            }

            if (mysteryNumber > numberGuess)
            {
                return 1;
            }

            return -1;
        }
    }

    public enum GuessResult
    {
        Greater = 1,
        Less = -1,
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
}
