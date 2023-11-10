using HiloGuessing.Domain.Entities;
using HiLoGuessing.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HiLoGuessing.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HiloController : ControllerBase
    {
        private readonly IMysteryNumberService _mysteryNumberService;
        private readonly IAttemptsService _attemptsService;
        private readonly IComparisonService _comparisonService;

        public HiloController(
            IMysteryNumberService mysteryNumberService,
            IAttemptsService attemptsService,
            IComparisonService comparisonService)
        {
            _mysteryNumberService = mysteryNumberService;
            _attemptsService = attemptsService;
            _comparisonService = comparisonService;
        }

        [HttpGet("MysteryNumber")]
        public async Task<ActionResult<int>> GetNumberAsync([FromQuery] int max = 10, [FromQuery] int min = 1)
        {
            var mysteryNumber = await _mysteryNumberService.GenerateNumber(max, min);
            return Ok(mysteryNumber);
        }

        [HttpGet("Attempts")]
        public ActionResult<int> GetAttempts()
        {
            var attempts = _attemptsService.GetAttempts();
            return Ok(attempts);
        }

        [HttpPost("MysteryNumber")]
        public async Task<ActionResult<GuessResponse>> SendNumber([FromQuery] int number)
        {
            var mysteryNumber = await _mysteryNumberService.GetMysteryNumber();
            var response = _comparisonService.CompareNumber(mysteryNumber, number);

            if (response.GuessResult == GuessResult.NotGenerated)
            {
                return BadRequest(response);
            }

            _attemptsService.IncrementAttempts();

            return Ok(response);
        }
    }
}
