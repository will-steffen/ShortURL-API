using ShortURL.DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShortURL.DomainModel.Entities
{
    public class BaseLogicalDeleteModel : BaseModel, IBaseLogicalDeleteModel
    {
        [Column("dt_logical_Delete")]
        public DateTime? LogicalDeleteDate { get; set; }

        public virtual void OnLogicalDelete() { }
    }
}
