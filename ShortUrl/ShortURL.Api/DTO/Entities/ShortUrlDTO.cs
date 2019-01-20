using ShortURL.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURL.Api.DTO.Entities
{
    public class ShortUrlDTO
    {
        public long id { get; set; }
        public string original { get; set; }
        public string shortUrl { get; set; }
        public string code { get; set; }

        public ShortUrlDTO() { }

        public ShortUrlDTO(ShortUrl url, string host)
        {
            id = url.Id;
            original = url.Original;
            code = url.Code;
            shortUrl = $"{host}/{url.Code}";
        }
    }
}
