using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiloGuessing.Domain.Interfaces;
using HiLoGuessing.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HiLoGuessing.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var DbPath = System.IO.Path.Join(path, "hilo.db");

            services.AddDbContext<MysteryNumberDbContext>(opt =>
                opt.UseSqlite($"Data Source={DbPath}",
                    b => b.MigrationsAssembly(typeof(MysteryNumberDbContext).Assembly.FullName)));

            services.AddScoped<IMysteryNumberRepository, IMysteryNumberRepository>();

            return services;
        }
    }
}
