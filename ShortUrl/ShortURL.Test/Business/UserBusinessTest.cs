using ShortURL.Business.Entities;
using ShortURL.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShortURL.Test.Business
{
    public class UserBusinessTest : IClassFixture<DependencyFixture>
    {
        private UserBusiness UserBusiness;

        public UserBusinessTest(DependencyFixture fixture)
        {
            UserBusiness = fixture.Resolve<UserBusiness>();
        }

        [Fact]
        public void Test_Create()
        {
            string fakeIp = "123.123.123.123";
            User user = UserBusiness.RequestNewUser(fakeIp);            
            Assert.True(user != null);
            Assert.True(user.Id > 0);
            Assert.Equal(user.Ip, fakeIp);
        }

        [Fact]
        public void Test_Find()
        {
            string fakeIp = "321.321.321.321";
            User userCreate = UserBusiness.RequestNewUser(fakeIp);
            User userFind = UserBusiness.FindById(userCreate.Id);
            Assert.Equal(userCreate.Id, userFind.Id);
        }
    }
}
