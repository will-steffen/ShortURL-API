using ShortURL.DomainModel;
using ShortURL.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortURL.DataAccess.Entities
{
    public class UserDataAccess : BaseDataAccess<User>
    {
        public UserDataAccess(ApplicationContext ctx) : base(ctx) { }

    }
}