using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShortURL.DomainModel.Entities
{
    public class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Column("dt_created")]
        public DateTime CreateDate { get; set; }

        [Column("dt_updated")]
        public DateTime UpdateDate { get; set; }
    }
}
