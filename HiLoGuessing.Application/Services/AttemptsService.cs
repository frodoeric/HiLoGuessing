using HiloGuessing.Domain.Interfaces;
using HiLoGuessing.Application.Services.Interfaces;
using HiLoGuessing.Infrastructure;

namespace HiLoGuessing.Application.Services
{
    public class AttemptsService : IAttemptsService
    {
        private readonly IRepository<Attempt> _attemptRepository;


        public AttemptsService(IRepository<Attempt> attemptRepository)
        {
            _attemptRepository = attemptRepository;
        }

        public async Task<List<Attempt>> GetAttempts()
        {
            return await _attemptRepository.GetAllAsync();
        }

        public async Task IncrementAttempts(Guid id)
        {
            var attempt = await _attemptRepository.GetByIdAsync(id);
            attempt.AttemptedNumber++;
            await _attemptRepository.UpdateAsync(attempt);
        }

        public async Task ResetAttempts()
        {
            //MysteryNumberRepository.NumberOfAttempts = 0;
        }

        public async Task SaveAttempts()
        {
            //MysteryNumberRepository.AttemptsList.Add(MysteryNumberRepository.NumberOfAttempts);
        }
    }
}
