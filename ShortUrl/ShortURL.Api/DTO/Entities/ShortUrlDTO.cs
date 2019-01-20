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

        public long countClick { get; set; } = 0;
        public DateTime createDate { get; set; }
        public List<ClickDTO> clickList { get; set; }

        public ShortUrlDTO() { }

        public ShortUrlDTO(ShortUrl url, string host, bool fullData = false)
        {
            id = url.Id;
            original = url.Original;
            code = url.Code;
            shortUrl = $"{host}/{url.Code}";

            if (fullData)
            {
                createDate = url.CreateDate;
                clickList = url.ClickList.Select(x => new ClickDTO(x)).ToList();
            }
        }
    }
}
