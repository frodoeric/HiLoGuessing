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
using Microsoft.Extensions.Options;

namespace HiLoGuessing.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //Todo: create param configuration
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var DbPath = System.IO.Path.Join(path, "hilo.db");

            services.AddDbContext<MysteryNumberDbContext>();

            services.AddScoped<IRepository<MysteryNumber>, MysteryNumberRepository>();
            services.AddScoped<IRepository<Attempt>, AttemptRepository>();

            return services;
        }
    }
}
