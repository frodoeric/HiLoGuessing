using System.Net.Security;
using HiloGuessing.Domain.Entities;
using HiloGuessing.Domain.Interfaces;
using HiLoGuessing.Application.Services;
using HiLoGuessing.Application.Services.Interfaces;
using HiLoGuessing.Infrastructure.Context;
using HiLoGuessing.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HiLoGuessing.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIoC(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<HiLoGuessDbContext>(options =>
                               options.UseSqlServer(configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));

            services.AddDbContext<HiLoGuessDbContext>();

            services.AddScoped<IHiLoGuessService, HiLoGuessService>();
            services.AddScoped<IAttemptsService, AttemptsService>();
            services.AddScoped<IComparisonService, ComparisonService>();
            services.AddScoped<IRepository<HiLoGuess>, MysteryNumberRepository>();
            services.AddScoped<IRepository<Attempts>, AttemptRepository>();

            return services;
        }
    }
}
