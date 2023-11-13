using System.Data;
using HiloGuessing.Domain.Interfaces;
using HiLoGuessing.Application.Services.Interfaces;
using HiloGuessing.Domain.Entities;
using Serilog;
using static System.Net.Mime.MediaTypeNames;

namespace HiLoGuessing.Application.Services
{
    public class HiLoGuessService : IHiLoGuessService
    {
        private readonly IRepository<HiLoGuess> _hiloRepository;
        private readonly ILogger _logger;

        public HiLoGuessService(IRepository<HiLoGuess> hiloRepository, ILogger logger)
        {
            _hiloRepository = hiloRepository;
            _logger = logger;
        }

        public async Task<List<HiLoGuess>> GetAllHiLoGuessesAsync()
        {
            try
            {
                _logger.Information("Getting all hilo guesses");
                return await _hiloRepository.GetAllAsync();
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error getting all hilo guesses");
                throw;
            }
        }

        public async Task<HiLoGuess> CreateHiLoGuessAsync(string playerName)
        {
            try
            {
                _logger.Information("Creating new hilo guess");
                var hilo = new HiLoGuess();
                var player = new Player() { Name = playerName };
                var attempt = new Attempts();

                hilo.Attempts = attempt;
                hilo.Player = player;

                return await _hiloRepository.AddAsync(hilo);
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error creating new hilo guess");
                throw;
            }
        }

        public async Task<int> CreateMysteryNumberAsync(Guid id, int max, int min)
        {
            try
            {
                _logger.Information("Creating new mystery number");
                var hilo = await _hiloRepository.GetByIdAsync(id);
                var next = new Random().Next(min, max);
                hilo.GeneratedMysteryNumber = next;

                await _hiloRepository.UpdateAsync(hilo);
                return next;
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error creating new mystery number");
                throw;
            }
        }

        public async Task UpdateHiLoGuessMysteryNumberAsync(Guid id, int generatedMysteryNumber)
        {
            try
            {
                _logger.Information("Updating hilo guess mystery number");
                var hilo = await _hiloRepository.GetByIdAsync(id);
                hilo.GeneratedMysteryNumber = generatedMysteryNumber;
                await _hiloRepository.UpdateAsync(hilo);
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error updating hilo guess mystery number");
            }
        }

        public async Task<int> GetMysteryNumberAsync(Guid id)
        {
            try
            {
                _logger.Information("Getting mystery number");
                var mysteryNumber = await _hiloRepository.GetByIdAsync(id);
                return mysteryNumber?.GeneratedMysteryNumber ?? 0;
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error getting mystery number");
                throw;
            }
        }

        public async Task ResetHiLoGuessAsync(Guid id)
        {
            try
            {
                _logger.Information("Resetting hilo guess");
                var hilo = await _hiloRepository.GetByIdAsync(id);
                hilo.GeneratedMysteryNumber = 0;
                await _hiloRepository.UpdateAsync(hilo);
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error resetting hilo guess");
                throw;
            }
        }

        public async Task<HiLoGuess> GetHiLoGuessAsync(Guid id)
        {
            try
            {
                _logger.Information("Getting hilo guess");
                var hilo = await _hiloRepository.GetByIdAsync(id);
                return hilo;
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error getting hilo guess");
                throw;
            }
        }
    }
}
