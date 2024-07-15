using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmirSacOtomotiv.Application.Absractions.Storage;
using EmirSacOtomotiv.Infrastructure.Services.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace EmirSacOtomotiv.Infrastructure
{
    public static class ServiceRegistrations
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
        }

        public static void AddStorage<T>(this IServiceCollection services) where T : class, IStorage
        {
            services.AddScoped<IStorage, T>();
        }
    }
}
