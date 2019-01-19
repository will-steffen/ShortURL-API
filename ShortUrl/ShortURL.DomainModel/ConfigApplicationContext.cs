using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShortURL.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortURL.DomainModel
{
    public class ConfigApplicationContext : DbContext
    {
        private static string ConnectionString;
        public static bool UseInMemory;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                ConnectionString = ApplicationEnv.GetStringConfiguration(Constants.DEFAULT_CONNECTION);
                UseInMemory = ApplicationEnv.GetBoolConfiguration(Constants.USE_MEMORY_DB);
            }
            if (UseInMemory)
            {
                optionsBuilder.UseInMemoryDatabase(Constants.MEMORY_DB_NAME);
            }
            else
            {
                optionsBuilder.UseMySql(ConnectionString);

            }
        }
    }
}
