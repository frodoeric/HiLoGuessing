using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiloGuessing.Domain.Interfaces;
using HiLoGuessing.Infrastructure;
using HiLoGuessing.Infrastructure.Context;
using HiLoGuessing.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HiLoGuessing.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IRepository<MysteryNumber>, MysteryNumberRepository>();
            services.AddScoped<IRepository<Attempt>, AttemptRepository>();

            return services;
        }
    }
}
