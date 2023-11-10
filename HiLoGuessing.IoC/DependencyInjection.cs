using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiloGuessing.Domain.Interfaces;
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
            services.AddScoped<IMysteryNumberRepository, MysteryNumberRepository>();

            return services;
        }
    }
}
