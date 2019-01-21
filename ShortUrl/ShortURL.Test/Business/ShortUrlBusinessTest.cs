using ShortURL.Business.Entities;
using ShortURL.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShortURL.Test.Business
{
    public class ShortUrlBusinessTest : IClassFixture<DependencyFixture>
    {
        private ShortUrlBusiness ShortUrlBusiness;
        private UserBusiness UserBusiness;
        private ClickBusiness ClickBusiness;

        private string referenceURL = @"https://google.com.br";
        private string fakeIp = "123.123.123.123";

        public ShortUrlBusinessTest(DependencyFixture fixture)
        {
            ShortUrlBusiness = fixture.Resolve<ShortUrlBusiness>();
            UserBusiness = fixture.Resolve<UserBusiness>();
            ClickBusiness = fixture.Resolve<ClickBusiness>();
        }

        [Fact]
        public void Test_CreateWithoutUser()
        {
            ShortUrl url = ShortUrlBusiness.MakeShortUrl(referenceURL);  
            
            Assert.NotNull(url);
            Assert.True(url.Id > 0);
            Assert.Null(url.User);
            Assert.Equal(referenceURL, url.Original);
            Assert.NotNull(url.Code);
        }

        [Fact]
        public void Test_CreateWithUser()
        {
            User user = UserBusiness.RequestNewUser(fakeIp);
            ShortUrl url = ShortUrlBusiness.MakeShortUrl(referenceURL, user.Id);

            Assert.NotNull(url);
            Assert.True(url.Id > 0);
            Assert.NotNull(url.User);
            Assert.Equal(user.Id, url.User.Id);
            Assert.Equal(referenceURL, url.Original);
            Assert.NotNull(url.Code);
        }

        [Fact]
        public void Test_FindByCode()
        {
            ShortUrl urlCreate = ShortUrlBusiness.MakeShortUrl(referenceURL);
            ShortUrl urlFind = ShortUrlBusiness.FindByCode(urlCreate.Code);

            Assert.Equal(urlCreate.Id, urlFind.Id);
            Assert.Equal(urlCreate.Code, urlFind.Code);
        }

        [Fact]
        public void Test_GetLast()
        {
            int countLastToShow = 2; // This could be as system parameter 

            User user = UserBusiness.RequestNewUser(fakeIp);
            ShortUrl urlCreate1 = ShortUrlBusiness.MakeShortUrl(referenceURL, user.Id);
            ShortUrl urlCreate2 = ShortUrlBusiness.MakeShortUrl(referenceURL, user.Id);
            ShortUrl urlCreate3 = ShortUrlBusiness.MakeShortUrl(referenceURL, user.Id);

            List<ShortUrl> urlList = ShortUrlBusiness.GetLastByIdUser(user.Id);

            Assert.Equal(countLastToShow, urlList.Count);
            Assert.Equal(urlCreate3.Code, urlList[0].Code);
            Assert.Equal(urlCreate2.Code, urlList[1].Code);
        }

        [Fact]
        public void Test_ClickedAndStats()
        {
            
            int clicksToShow = 10; // This could be as system parameter
            int clickCount = clicksToShow + 4;

            ShortUrl url = ShortUrlBusiness.MakeShortUrl(referenceURL);
            for(int i = 0; i < clickCount; i++)
            {
                ShortUrlBusiness.Clicked(url.Code, fakeIp);
            }

            ShortUrl urlStats = ShortUrlBusiness.Stats(url.Code);
            long counted = ClickBusiness.CountClicksByCode(url.Code);

            Assert.Equal(clicksToShow, urlStats.ClickList.Count);
            Assert.Equal(clickCount, counted);
        }
    }
}

