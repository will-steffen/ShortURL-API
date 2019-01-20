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

        [Column("id_user")]
        public long IdUser { get; set; }

        [ForeignKey("IdUser")]
        [InverseProperty("ShortUrlList")]
        public virtual User User { get; set; } 

        public virtual List<Click> ClickList { get; set; }
    }
}
