using ShortURL.DataAccess.Entities;
using ShortURL.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortURL.Business.Entities
{
    public class BaseBusiness<TModel, TDataAccess> where TModel : BaseModel where TDataAccess : BaseDataAccess<TModel>
    {
        protected TDataAccess DataAccess;

        public BaseBusiness(TDataAccess da)
        {
            DataAccess = da;
        }

        public IEnumerable<TModel> List()
        {
            return DataAccess.List();
        }

        public virtual TModel GetById(long id)
        {
            return DataAccess.GetById(id);
        }

        public virtual void Save(TModel model)
        {
            DataAccess.Save(model);
        }

        public virtual void Delete(TModel model)
        {
            DataAccess.Delete(model);
        }
    }
}
