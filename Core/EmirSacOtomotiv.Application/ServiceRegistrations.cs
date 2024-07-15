using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EmirSacOtomotiv.Application
{
    public static class ServiceRegistrations
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            Assembly assm = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistrations).Assembly));
            services.AddAutoMapper(assm);
        }
    }
}
 