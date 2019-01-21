using Microsoft.AspNetCore.Http;
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
    public class UserBusiness : BaseBusiness<User, UserDataAccess>
    {
        public UserBusiness(UserDataAccess da) : base(da) { }

        public User RequestNewUser(string clientIp)
        {
            User user = new User();
            user.Ip = clientIp;
            Save(user);
            return user;
        }

        public User FindById(long id)
        {
            User user = GetById(id);
            if(user == null)
            {
                throw new EntityNotFoundException("user not found");
            }
            return user;
        }
    }
}
