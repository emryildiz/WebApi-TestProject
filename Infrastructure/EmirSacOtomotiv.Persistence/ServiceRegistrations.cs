using EmirSacOtomotiv.Application.Repositories.Products;
using EmirSacOtomotiv.Persistence.Repositories.Products;
using Microsoft.Extensions.DependencyInjection;

namespace EmirSacOtomotiv.Persistence
{
    public static class ServiceRegistrations
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
        }
    }
}
