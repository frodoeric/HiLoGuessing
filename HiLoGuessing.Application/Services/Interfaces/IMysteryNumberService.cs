﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiLoGuessing.Infrastructure;

namespace HiLoGuessing.Application.Services.Interfaces
{
    public interface IMysteryNumberService
    {
        Task<HiLoGuess> CreateHiLoGuessAsync();
        Task<int> CreateMysteryNumberAsync(Guid id, int max, int min);
        Task<int> GetMysteryNumberAsync(Guid id);
        Task<HiLoGuess> ResetHiLoGuessAsync();
    }
}
