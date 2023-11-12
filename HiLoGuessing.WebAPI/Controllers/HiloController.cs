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
        private readonly IHiLoGuessService _hiLoGuessService;
        private readonly IAttemptsService _attemptsService;
        private readonly IComparisonService _comparisonService;

        public HiloController(
            IHiLoGuessService hiLoGuessService,
            IAttemptsService attemptsService,
            IComparisonService comparisonService)
        {
            _hiLoGuessService = hiLoGuessService;
            _attemptsService = attemptsService;
            _comparisonService = comparisonService;
        }

        [HttpGet("HiLoGuess/Start")]
        public async Task<ActionResult<HiLoGuess>> Start()
        {
            var mysteryNumber = await _hiLoGuessService.CreateHiLoGuessAsync();
            return Ok(mysteryNumber);
        }

        [HttpGet("HiLoGuess/GetHiLoGuessById")]
        public async Task<ActionResult<HiLoGuess>> GetById(
            [FromHeader] Guid id)
        {
            var hilo = await _hiLoGuessService.GetHiLoGuessAsync(id);
            return Ok(hilo);
        }

        [HttpGet("Attempts/GetAllHiLoGuess")]
        public async Task<ActionResult<List<HiLoGuess>>> GetAll()
        {
            var hiloGuess = await _hiLoGuessService.GetAllHiLoGuessesAsync();
            return Ok(hiloGuess);
        }

        [HttpPost("HiLoGuess/GenerateMysteryNumber")]
        public async Task<ActionResult<int>> GenerateMysteryNumber(
            [FromBody] GenerateNumberRequest? request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request body");
            }
            var mysteryNumber = await _hiLoGuessService
                .CreateMysteryNumberAsync(request.HiLoGuessId, request.Max, request.Min);
            return Ok(mysteryNumber);
        }

        [HttpPost("HiLoGuess/SendGuessNumber")]
        public async Task<ActionResult<GuessResponse<HiLoGuess>>> SendNumber(
            [FromBody] SendNumberRequest request)
        {
            var mysteryNumber = await _hiLoGuessService.GetMysteryNumberAsync(request.HiLoGuessId);
            var response = await _comparisonService.CompareNumber(
                request.HiLoGuessId, mysteryNumber, request.Number);

            if (response.GuessResult == GuessResult.NotGenerated)
            {
                return BadRequest(response);
            }

            await _attemptsService.IncrementAttempts(response.Data.Attempts.AttemptsId);

            return Ok(response);
        }
    }
}
