using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShortURL.DomainModel.Entities
{
    [Table("click")]
    public class Click : BaseModel
    {
        [Column("txt_ip")]
        public string Ip { get; set; }

        [Column("id_short_url")]
        [Required]
        public long IdShortUrl { get; set; }

        [ForeignKey("IdShortUrl")]
        [InverseProperty("ClickList")]
        public virtual ShortUrl ShortUrl { get; set; }
    }
}
