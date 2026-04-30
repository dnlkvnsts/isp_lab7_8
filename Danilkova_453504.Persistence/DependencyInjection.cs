using Danilkova_453504.Persistence.Data;
using Danilkova_453504.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this  IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork,FakeUnitOfWork>();
            return services;
        }


        public static IServiceCollection AddPersistence(this IServiceCollection services, DbContextOptions options)
        {
            services.AddPersistence()
            .AddSingleton<AppDbContext>(
                new AppDbContext((DbContextOptions<AppDbContext>)options));
            return services;
        }


    }
}
