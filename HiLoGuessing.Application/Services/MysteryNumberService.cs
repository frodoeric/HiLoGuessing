using HiloGuessing.Domain.Interfaces;
using HiLoGuessing.Application.Services.Interfaces;
using HiLoGuessing.Infrastructure;

namespace HiLoGuessing.Application.Services
{
    public class MysteryNumberService : IMysteryNumberService
    {
        private readonly IRepository<MysteryNumber> _mysteryNumbeRepository;
        public MysteryNumber MysteryNumber { get; set; }
        public MysteryNumberService()
        {
            MysteryNumber = new MysteryNumber();
        }
        public int GenerateNumber(int max, int min)
        {
            //todo create entity
            var next = new Random().Next(min, max);
            MysteryNumber.GeneratedMysteryNumber = next;

            _mysteryNumbeRepository.AddAsync(MysteryNumber);
            //MysteryNumberRepository.MysteryNumber = next;
            return next;
        }

        public int GetMysteryNumber()
        {
            //_mysteryNumbeRepository.GetByIdAsync()
            return 0;
        }

        public void ResetMysteryNumber()
        {
            //MysteryNumberRepository.MysteryNumber = 0;
        }
    }
}
