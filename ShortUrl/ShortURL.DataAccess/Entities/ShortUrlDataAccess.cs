﻿using Microsoft.EntityFrameworkCore;
using ShortURL.DomainModel;
using ShortURL.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortURL.DataAccess.Entities
{
    public class ShortUrlDataAccess : BaseDataAccess<ShortUrl>
    {
        public ShortUrlDataAccess(ApplicationContext ctx) : base(ctx) { }

        public ShortUrl GetByCode(string code)
        {
            return GetBaseQueryable().Where(x => x.Code == code).FirstOrDefault();
        }

        public IEnumerable<ShortUrl> GetLastByIdUser(long userId, int count)
        {
            return GetBaseQueryable().Where(x => x.IdUser == userId).OrderByDescending(x => x.Id).Take(count);
        }
        
    }
}
