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
            //todo get by id
            return await _attemptRepository.GetAllAsync();
        }

        public void IncrementAttempts()
        {
            //MysteryNumberRepository.NumberOfAttempts++;
        }

        public void ResetAttempts()
        {
            //MysteryNumberRepository.NumberOfAttempts = 0;
        }

        public void SaveAttempts()
        {
            //MysteryNumberRepository.AttemptsList.Add(MysteryNumberRepository.NumberOfAttempts);
        }
    }
}
