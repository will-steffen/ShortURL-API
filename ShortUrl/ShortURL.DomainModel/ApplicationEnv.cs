using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShortURL.DomainModel
{
    public class ApplicationEnv
    {
        public static IConfigurationRoot Configuration { get; set; }    
        public static IServiceProvider ServiceProvider { get; set; }

        public static IConfigurationRoot GetConfiguration()
        {
            if (Configuration != null) return Configuration;

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile(Constants.CONFIG_FILE_NAME, optional: true);
            Configuration = builder.Build();
            return Configuration;
        }

        public static string GetApiUrl(HttpContext httpContext)
        {
            string scheme = GetBoolConfiguration(Constants.FORCE_HTTPS_LINK) ? "https" : httpContext.Request.Scheme;
            return $"{scheme}://{httpContext.Request.Host.Value}";
        }

        public static string GetStringConfiguration(string key)
        {
            string value = Environment.GetEnvironmentVariable(GetAzureKeyString(key));
            if (value == null)
            {
                IConfigurationRoot config = GetConfiguration();
                value = config.GetValue<string>(key);
            }
            return value;
        }

        public static bool GetBoolConfiguration(string key)
        {
            string value = GetStringConfiguration(key);
            return Constants.TRUE.Equals(value) || Constants.TRUE.ToLower().Equals(value);
        }

        public static int GetIntConfiguration(string key)
        {
            string value = GetStringConfiguration(key);
            if (value == null) return 0;
            return Int32.Parse(value);
        }   

        private static string GetAzureKeyString(string key)
        {
            return key.Replace(":", ".");
        }
    }
}
