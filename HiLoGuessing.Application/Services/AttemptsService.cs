using HiloGuessing.Domain.Interfaces;
using HiLoGuessing.Application.Services.Interfaces;
using HiloGuessing.Domain.Entities;
using Serilog;

namespace HiLoGuessing.Application.Services
{
    public class AttemptsService : IAttemptsService
    {
        private readonly IRepository<Attempts> _attemptRepository;
        private readonly ILogger _logger;


        public AttemptsService(IRepository<Attempts> attemptRepository,
            ILogger logger)
        {
            _attemptRepository = attemptRepository;
            _logger = logger;
        }

        public async Task<List<Attempts>> GetAttempts()
        {
            try
            {
                _logger.Information("Getting all attempts");
                return await _attemptRepository.GetAllAsync();
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error getting all attempts");
                throw;
            }
        }

        public async Task IncrementAttempts(Guid id)
        {
            try
            {
                _logger.Information("Incrementing attempts");
                var attempt = await _attemptRepository.GetByIdAsync(id);
                attempt.NumberOfAttempts++;
                await _attemptRepository.UpdateAsync(attempt);
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error incrementing attempts");
                throw;
            }
        }
    }
}
