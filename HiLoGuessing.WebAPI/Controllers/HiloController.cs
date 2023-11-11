using HiLoGuessing.Application.Requests;
using HiloGuessing.Domain.Entities;
using HiLoGuessing.Application.Services.Interfaces;
using HiLoGuessing.Infrastructure;
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

        [HttpGet("HiLoGuess/Start")]
        public async Task<ActionResult<HiLoGuess>> Start()
        {
            var mysteryNumber = await _mysteryNumberService.CreateHiLoGuessAsync();
            return Ok(mysteryNumber);
        }

        [HttpPost("HiLoGuess/GetNumber")]
        public async Task<ActionResult<int>> GetNumberAsync(
            [FromBody] GenerateNumberRequest? request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request body");
            }
            var mysteryNumber = await _mysteryNumberService
                .CreateMysteryNumberAsync(request.Id, request.Max, request.Min);
            return Ok(mysteryNumber);
        }

        [HttpGet("Attempts")]
        public ActionResult<int> GetAttempts()
        {
            var attempts = _attemptsService.GetAttempts();
            return Ok(attempts);
        }

        [HttpPost("HiLoGuess")]
        public async Task<ActionResult<GuessResponse<HiLoGuess>>> SendNumber(
            [FromBody] SendNumberRequest request)
        {
            var mysteryNumber = await _mysteryNumberService.GetMysteryNumberAsync(request.HiloId);
            var response = await _comparisonService.CompareNumber(mysteryNumber, request.Number);

            if (response.GuessResult == GuessResult.NotGenerated)
            {
                return BadRequest(response);
            }

            await _attemptsService.IncrementAttempts(request.AttemptsId);

            return Ok(response);
        }
    }
}
