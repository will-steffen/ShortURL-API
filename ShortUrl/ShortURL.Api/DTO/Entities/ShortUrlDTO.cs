using ShortURL.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURL.Api.DTO.Entities
{
    public class ShortUrlDTO
    {
        public string ori { get; set; }
        public string username { get; set; }

        public ShortUrlDTO() { }

        public ShortUrlDTO(ShortUrl sh)
        {

        }
    }
}
