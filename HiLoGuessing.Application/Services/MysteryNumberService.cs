using HiloGuessing.Domain.Interfaces;
using HiLoGuessing.Application.Services.Interfaces;
using HiLoGuessing.Infrastructure;

namespace HiLoGuessing.Application.Services
{
    public class MysteryNumberService : IMysteryNumberService
    {
        private readonly IRepository<HiLoGuess> _hiloRepository;

        public MysteryNumberService(IRepository<HiLoGuess> hiloRepository)
        {
            _hiloRepository = hiloRepository;
        }

        public async Task<HiLoGuess> CreateHiLoGuessAsync()
        {
            var hilo = new HiLoGuess();
            return await _hiloRepository.AddAsync(hilo);
        }

        public async Task<int> CreateMysteryNumberAsync(Guid id, int max, int min)
        {
            var hilo = await _hiloRepository.GetByIdAsync(id);
            var next = new Random().Next(min, max);
            hilo.GeneratedMysteryNumber = next;

            await _hiloRepository.UpdateAsync(hilo);
            return next;
        }

        public async Task<int> GetMysteryNumberAsync(Guid id)
        {
            var mysteryNumber = await _hiloRepository.GetByIdAsync(id);
            return mysteryNumber?.GeneratedMysteryNumber ?? 0;
        }

        public async Task<HiLoGuess> ResetHiLoGuessAsync()
        {
            var hilo = new HiLoGuess();
            return await _hiloRepository.AddAsync(hilo);
        }
    }
}
