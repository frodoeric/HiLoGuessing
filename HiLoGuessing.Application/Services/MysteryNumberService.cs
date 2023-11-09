using HiLoGuessing.Application.Services.Interfaces;

namespace HiLoGuessing.Application.Services
{
    public class MysteryNumberService : IMysteryNumberService
    {
        public int GenerateNumber(int max, int min)
        {
            var next = new Random().Next(min, max);
            //MysteryNumberRepository.MysteryNumber = next;
            return next;
        }

        public int GetMysteryNumber()
        {
            //return MysteryNumberRepository.MysteryNumber;
            return 0;
        }

        public void ResetMysteryNumber()
        {
            //MysteryNumberRepository.MysteryNumber = 0;
        }
    }
}
