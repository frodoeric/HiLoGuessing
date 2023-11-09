using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoGuessing.Application.Services.Interfaces
{
    public interface IMysteryNumberService
    {
        int GenerateNumber(int max, int min);
        int GetMysteryNumber();
        void ResetMysteryNumber();
    }
}
