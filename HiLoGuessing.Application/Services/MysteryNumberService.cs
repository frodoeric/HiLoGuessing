using HiLoGuessing.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiLoGuessing.Infrastructure;

namespace HiLoGuessing.Application.Services
{
    public class MysteryNumberService : IMysteryNumberService
    {
        public int GenerateNumber(int max, int min)
        {
            var random = new Random();
            MysteryNumberRepository.MysteryNumber = random.Next(min, max);
            return MysteryNumberRepository.MysteryNumber;
        }

        public int GetMysteryNumber()
        {
            return MysteryNumberRepository.MysteryNumber;
        }

        public void ResetMysteryNumber()
        {
            MysteryNumberRepository.MysteryNumber = 0;
        }
    }
}
