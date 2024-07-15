using Microsoft.Extensions.Configuration;

namespace EmirSacOtomotiv.Persistence
{
    public static class Configuration
    {
        public static string ConnectiongString
        {
            get
            {
                ConfigurationManager configurationManager = new();

                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Eticaret.WebApi"))
                                    .AddJsonFile("appsettings.json")
                                    .Build();

                return configurationManager.GetConnectionString("EmirSacOtomotivPostgre");
            }
        }
    }
}
