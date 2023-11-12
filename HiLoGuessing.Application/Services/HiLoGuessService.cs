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

        public async Task<HiLoGuess> CreateHiLoGuessAsync()
        {
            var hilo = new HiLoGuess();
            var attempt = new Attempts();

            hilo.Attempts = attempt;

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

        private HiLoGuessDto GetHiLoGuessDto(HiLoGuess hiLoGuessEntity)
        {
            var hiLoGuessDto = new HiLoGuessDto
            {
                HiLoGuessId = hiLoGuessEntity.HiLoGuessId,
                GeneratedMysteryNumber = hiLoGuessEntity.GeneratedMysteryNumber,
                NumberOfAttempts = hiLoGuessEntity.Attempts?.NumberOfAttempts ?? 0,
                Attempts = new AttemptsDto
                {
                    AttemptsId = hiLoGuessEntity.Attempts.AttemptsId,
                    NumberOfAttempts = hiLoGuessEntity.Attempts.NumberOfAttempts
                }
            };

            return hiLoGuessDto;
        }
    }

    public class HiLoGuessDto
    {
        public Guid HiLoGuessId { get; set; }
        public int GeneratedMysteryNumber { get; set; }
        public int NumberOfAttempts { get; set; }

        public AttemptsDto Attempts { get; set; }
    }

    public class AttemptsDto
    {
        public Guid AttemptsId { get; set; }
        public int NumberOfAttempts { get; set; }
    }

}
