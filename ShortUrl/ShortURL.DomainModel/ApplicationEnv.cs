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
            return $"{httpContext.Request.Scheme}://{httpContext.Request.Host.Value}";
        }
    }
}
