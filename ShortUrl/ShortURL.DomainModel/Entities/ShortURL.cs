using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShortURL.DomainModel.Entities
{
    [Table("short_url")]
    public class ShortUrl : BaseModel
    {
        [Column("txt_original")]
        public string Original { get; set; }

        [Column("txt_code")]
        public string Code { get; set; }
    }
}
