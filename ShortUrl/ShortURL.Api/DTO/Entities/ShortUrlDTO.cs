using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURL.Api.DTO.Entities
{
    public class ShortUrlDTO
    {
        public string original { get; set; }
        public string shortUrl { get; set; }
    }
}
