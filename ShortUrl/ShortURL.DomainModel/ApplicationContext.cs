using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShortURL.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortURL.DomainModel
{
    public class ApplicationContext : ConfigApplicationContext
    {
        public DbSet<ShortUrl> ShortUrl { get; set; }    
    }
}
