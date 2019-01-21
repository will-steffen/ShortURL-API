using ShortURL.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURL.Api.DTO.Entities
{
    public class SaveShortUrlRequestDTO
    {
        public string url { get; set; } 
        public long? userId { get; set; }
    }
}
