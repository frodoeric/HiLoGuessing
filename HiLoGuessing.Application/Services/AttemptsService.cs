using HiloGuessing.Domain.Interfaces;
using HiLoGuessing.Application.Services.Interfaces;
using HiloGuessing.Domain.Entities;

namespace HiLoGuessing.Application.Services
{
    public class AttemptsService : IAttemptsService
    {
        private readonly IRepository<Attempts> _attemptRepository;


        public AttemptsService(IRepository<Attempts> attemptRepository)
        {
            _attemptRepository = attemptRepository;
        }

        public async Task<List<Attempts>> GetAttempts()
        {
            return await _attemptRepository.GetAllAsync();
        }

        public async Task IncrementAttempts(Guid id)
        {
            var attempt = await _attemptRepository.GetByIdAsync(id);
            attempt.NumberOfAttempts++;
            await _attemptRepository.UpdateAsync(attempt);
        }
    }
}
