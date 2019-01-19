using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShortURL.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortURL.DomainModel
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ShortUrl> ShortUrl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = ApplicationEnv.GetConfiguration().GetValue<string>(Constants.DEFAULT_CONNECTION);
            optionsBuilder.UseMySql(connString);
        }
    }
}
