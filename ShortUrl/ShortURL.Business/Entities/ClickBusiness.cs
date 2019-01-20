using ShortURL.DataAccess.Entities;
using ShortURL.DomainModel;
using ShortURL.DomainModel.Entities;
using ShortURL.DomainModel.Exceptions;
using ShortURL.DomainModel.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortURL.Business.Entities
{
    public class ClickBusiness : BaseBusiness<Click, ClickDataAccess>
    {
        public ClickBusiness(ClickDataAccess da) : base(da) { }

        public long CountClicksByCode(string code)
        {
            return DataAccess.CountClicksByCode(code);
        }
      
    }
}
