using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShortURL.DomainModel;
using ShortURL.DomainModel.Entities;
using ShortURL.DomainModel.Interfaces;

namespace ShortURL.DataAccess.Entities
{
    public class BaseDataAccess<TModel> where TModel : BaseModel
    {
        protected ApplicationContext Context;
        
        public BaseDataAccess(ApplicationContext ctx)
        {
            Context = ctx;
        }

        public bool IsLogicalDelete()
        {
            return typeof(IBaseLogicalDeleteModel).IsAssignableFrom(typeof(TModel));
        }

        private void SaveChanges()
        {
            Context.SaveChanges();
        }

        public virtual IEnumerable<TModel> List()
        {            
            if (IsLogicalDelete())
            {
                return GetBaseQueryable().Where(x => ((IBaseLogicalDeleteModel)x).LogicalDeleteDate == null);
            }
            return GetBaseQueryable();
        }

        public virtual TModel GetById(long id)
        {
            if (IsLogicalDelete())
            {
                return GetBaseQueryable()
                    .Where(x => x.Id == id && ((IBaseLogicalDeleteModel)x).LogicalDeleteDate == null)
                    .FirstOrDefault();
            }
            return GetBaseQueryable().FirstOrDefault(x => x.Id == id);
        }

        public virtual void Save(TModel model)
        {
            DbSet<TModel> set = Context.Set<TModel>();
            model.UpdateDate = DateTime.Now;
            if(model.Id == 0)
            {
                model.CreateDate = model.UpdateDate;
                set.Add(model);
            }
            else
            {
                set.Attach(model);
                Context.Entry(model).State = EntityState.Modified;
            }
            SaveChanges();
        }

        public virtual void Delete(TModel model)
        {
            if (IsLogicalDelete())
            {
                ((IBaseLogicalDeleteModel)model).LogicalDeleteDate = DateTime.Now;
                Save(model);
            }
            else
            {
                Context.Set<TModel>().Remove(model);
                SaveChanges();
            }            
        }

        public virtual IQueryable<TModel> GetBaseQueryable()
        {
            return Context.Set<TModel>();
        }
    }
}
