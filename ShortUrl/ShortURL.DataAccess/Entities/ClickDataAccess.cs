using ShortURL.DomainModel;
using ShortURL.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortURL.DataAccess.Entities
{
    public class ClickDataAccess : BaseDataAccess<Click>
    {
        public ClickDataAccess(ApplicationContext ctx) : base(ctx) { }

        public long CountClicksByCode(string code)
        {
            return GetBaseQueryable().Where(x => x.ShortUrl.Code.Equals(code)).Count();
        }

        public IEnumerable<Click> GetByShortUrlCode(string code, int count)
        {
            return GetBaseQueryable()
                .Where(x => x.ShortUrl.Code.Equals(code))
                .OrderByDescending(x => x.Id)
                .Take(count);
        }
    }
}
