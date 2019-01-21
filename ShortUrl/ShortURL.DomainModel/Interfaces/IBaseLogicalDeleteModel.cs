using System;
using System.Collections.Generic;
using System.Text;

namespace ShortURL.DomainModel.Interfaces
{
    public interface IBaseLogicalDeleteModel
    {
        DateTime? LogicalDeleteDate { get; set; }
        void OnLogicalDelete();
    }
}
