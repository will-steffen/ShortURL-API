using ShortURL.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURL.Api.DTO.Entities
{
    public class SaveShortUrlRequestDTO
    {
        public string original { get; set; } 
        public string shortUrl { get; set; }
    }
}
