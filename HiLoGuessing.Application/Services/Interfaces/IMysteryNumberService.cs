using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoGuessing.Application.Services.Interfaces
{
    public interface IMysteryNumberService
    {
        Task<int> GenerateNumber(int max, int min);
        Task<int> GetMysteryNumber();
        void ResetMysteryNumber();
    }
}
