using Microsoft.Extensions.Configuration;

namespace Utiliy.Helper
{
    public static class AppSettingsHelper
    {
        public static readonly IConfigurationRoot Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

        public static T GetValue<T>(string key, T defaultValue)
        {
            var value = Configuration.GetValue<T>(key, defaultValue);

            if (value == null)
                return defaultValue;

            if (string.IsNullOrEmpty(value.ToString()))
                return defaultValue;

            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
