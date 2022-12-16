using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace ShopVsk.Tests
{
    public class ConfigurationManager
    {
        public AppSettings GetSettings()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            var settings = config.Get<AppSettings>();

            return settings;
        }
    }
}