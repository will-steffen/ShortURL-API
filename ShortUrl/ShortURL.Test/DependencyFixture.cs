using Microsoft.Extensions.DependencyInjection;
using ShortURL.Business.Entities;
using ShortURL.DataAccess.Entities;
using ShortURL.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortURL.Test
{
    public class DependencyFixture
    {
        private ApplicationContext Context;
        public ServiceProvider ServiceProvider { get; private set; }

        public DependencyFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<ApplicationContext>();            

            serviceCollection.AddScoped<ShortUrlBusiness>();
            serviceCollection.AddScoped<ClickBusiness>();
            serviceCollection.AddScoped<UserBusiness>();

            serviceCollection.AddScoped<ShortUrlDataAccess>();
            serviceCollection.AddScoped<ClickDataAccess>();
            serviceCollection.AddScoped<UserDataAccess>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }


        public TDependency Resolve<TDependency>()
        {
            return ServiceProvider.GetService<TDependency>();
        }

    }
}
