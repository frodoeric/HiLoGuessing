﻿using HiLoGuessing.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoGuessing.Application.Services.Interfaces
{
    public interface IAttemptsService
    {
        Task<List<Attempt>> GetAttempts();
        Task IncrementAttempts(Guid id);
        Task SaveAttempts();
        Task ResetAttempts();
    }
}
