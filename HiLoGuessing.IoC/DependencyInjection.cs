using System.Net.Security;
using HiloGuessing.Domain.Entities;
using HiloGuessing.Domain.Interfaces;
using HiLoGuessing.Application.Services;
using HiLoGuessing.Application.Services.Interfaces;
using HiLoGuessing.Infrastructure.Context;
using HiLoGuessing.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HiLoGuessing.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIoC(this IServiceCollection services,
            string connection)
        {
            services.AddDbContext<MysteryNumberDbContext>(options =>
                               options.UseSqlServer(connection));

            services.AddDbContext<MysteryNumberDbContext>();

            services.AddScoped<IHiLoGuessService, HiLoGuessService>();
            services.AddScoped<IAttemptsService, AttemptsService>();
            services.AddScoped<IComparisonService, ComparisonService>();
            services.AddScoped<IRepository<HiLoGuess>, MysteryNumberRepository>();
            services.AddScoped<IRepository<Attempts>, AttemptRepository>();

            return services;
        }
    }
}
