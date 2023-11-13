using HiloGuessing.Domain.Interfaces;
using HiLoGuessing.Application.Services.Interfaces;
using HiloGuessing.Domain.Entities;

namespace HiLoGuessing.Application.Services
{
    public class HiLoGuessService : IHiLoGuessService
    {
        private readonly IRepository<HiLoGuess> _hiloRepository;

        public HiLoGuessService(IRepository<HiLoGuess> hiloRepository)
        {
            _hiloRepository = hiloRepository;
        }

        public async Task<List<HiLoGuess>> GetAllHiLoGuessesAsync()
        {
            return await _hiloRepository.GetAllAsync();
        }

        public async Task<HiLoGuess> CreateHiLoGuessAsync(string playerName)
        {
            //todo: create require property
            var hilo = new HiLoGuess();
            var player = new Player() { Name = playerName };
            var attempt = new Attempts();

            hilo.Attempts = attempt;
            hilo.Player = player;

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

        public async Task ResetHiLoGuessAsync(Guid id)
        {
            var hilo = await _hiloRepository.GetByIdAsync(id);
            hilo.GeneratedMysteryNumber = 0;
            await _hiloRepository.UpdateAsync(hilo);
        }

        public async Task<HiLoGuess> GetHiLoGuessAsync(Guid id)
        {
            var hilo = await _hiloRepository.GetByIdAsync(id);
            return hilo;
        }
    }
}
