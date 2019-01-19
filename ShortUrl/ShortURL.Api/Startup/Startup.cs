using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ShortURL.Business.Entities;
using ShortURL.DataAccess.Entities;
using ShortURL.DomainModel;

namespace ShortURL.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddCors(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ApplicationContext>();

            services.AddScoped<ShortUrlBusiness>();

            services.AddScoped<ShortUrlDataAccess>();

            RunMigrations();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(Constants.CORS_POLICY_NAME);
            //app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void RunMigrations()
        {            
            if (!ApplicationEnv.GetBoolConfiguration(Constants.USE_MEMORY_DB))
            {
                ApplicationContext ctx = Activator.CreateInstance<ApplicationContext>();
                ctx.Database.Migrate();
            }
        }

        private void AddCors(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy(Constants.CORS_POLICY_NAME, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }
    }
}
