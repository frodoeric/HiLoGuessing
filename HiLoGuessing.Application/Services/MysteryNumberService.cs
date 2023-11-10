using HiloGuessing.Domain.Interfaces;
using HiLoGuessing.Application.Services.Interfaces;
using HiLoGuessing.Infrastructure;

namespace HiLoGuessing.Application.Services
{
    public class MysteryNumberService : IMysteryNumberService
    {
        private readonly IRepository<MysteryNumber> _mysteryNumbeRepository;
        public MysteryNumber MysteryNumber { get; set; }

        public MysteryNumberService(IRepository<MysteryNumber> mysteryNumbeRepository)
        {
            _mysteryNumbeRepository = mysteryNumbeRepository;
            MysteryNumber = new MysteryNumber();
        }

        public async Task<int> GenerateNumber(int max, int min)
        {
            //todo create entity
            var next = new Random().Next(min, max);
            MysteryNumber.GeneratedMysteryNumber = next;

            await _mysteryNumbeRepository.AddAsync(MysteryNumber);
            //MysteryNumberRepository.MysteryNumber = next;
            return next;
        }

        public async Task<int> GetMysteryNumber()
        {
            //_mysteryNumbeRepository.GetByIdAsync()
            var result = await _mysteryNumbeRepository.GetAllAsync();
            return 0;
        }

        public void ResetMysteryNumber()
        {
            //MysteryNumberRepository.MysteryNumber = 0;
        }
    }
}
