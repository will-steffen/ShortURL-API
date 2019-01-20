using ShortURL.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURL.Api.DTO.Entities
{
    public class ClickDTO
    {
        public long id { get; set; }
        public string ip { get; set; }
        public DateTime createDate { get; set; }

        public ClickDTO() { }

        public ClickDTO(Click click)
        {
            id = click.Id;
            ip = click.Ip;
            createDate = click.CreateDate;
        }
    }
}
