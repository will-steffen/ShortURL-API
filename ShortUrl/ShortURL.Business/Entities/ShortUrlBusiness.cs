using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ShortURL.DataAccess.Entities;
using ShortURL.DomainModel;
using ShortURL.DomainModel.Entities;
using ShortURL.DomainModel.Exceptions;
using ShortURL.DomainModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortURL.Business.Entities
{
    public class ShortUrlBusiness : BaseBusiness<ShortUrl, ShortUrlDataAccess>
    {
        private UserBusiness UserBusiness;
        private ClickBusiness ClickBusiness;

        public ShortUrlBusiness(ShortUrlDataAccess da, UserBusiness userBusiness, ClickBusiness clickBusiness) : base(da)
        {
            UserBusiness = userBusiness;
            ClickBusiness = clickBusiness;
        }

        public ShortUrl MakeShortUrl(string originalUrl, long? userId = null)
        {
            if (!Uri.IsWellFormedUriString(originalUrl, UriKind.Absolute))
            {
                throw new InvalidUrlException();
            }            

            ShortUrl url = new ShortUrl
            {
                Original = originalUrl,
                Code = GetNewCode()
            };

            if (userId != null)
            {
                url.User = UserBusiness.FindById(userId.Value);
            }

            Save(url);
            return url;
        }

        public ShortUrl FindByCode(string code)
        {
            ShortUrl url = DataAccess.GetByCode(code);
            if(url == null)
            {
                throw new EntityNotFoundException("code not valid");
            }
            return url;
        }

        public List<ShortUrl> GetLastByIdUser(long userId)
        {
            int countLastToShow = 2; // This could be as system parameter 
            return DataAccess.GetLastByIdUser(userId, countLastToShow).ToList();
        }

        private string GetNewCode()
        {
            int length = ApplicationEnv.GetIntConfiguration(Constants.SHORT_URL_CODE_LENGTH);
            string code = TokenUtils.GenerateCode(length);
            while (DataAccess.GetByCode(code) != null)
            {
                code = TokenUtils.GenerateCode(length);
            }
            return code;
        }

        public ShortUrl Clicked(string code, HttpContext httpContext)
        {
            ShortUrl url = FindByCode(code);
            Click click = new Click() {
                ShortUrl = url,
                Ip = ApplicationEnv.GetClientIP(httpContext)
            };
            ClickBusiness.Save(click);
            return url;
        }

        public ShortUrl Stats(string code)
        {
            ShortUrl url = FindByCode(code);
            int clicksToShow = 10; // This could be as system parameter 
            url.ClickList = ClickBusiness.GetByShortUrlCode(code, clicksToShow);
            return url;
        }
    }
}
