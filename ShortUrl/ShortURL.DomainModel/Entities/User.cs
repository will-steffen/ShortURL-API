using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShortURL.DomainModel.Entities
{
    [Table("user")]
    public class User : BaseModel
    {
        [Column("txt_ip")]
        public string Ip { get; set; }

        public virtual List<ShortUrl> ShortUrlList { get; set; }
    }
}
