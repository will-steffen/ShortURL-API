using Microsoft.Extensions.Configuration;
using ShortURL.DataAccess.Entities;
using ShortURL.DomainModel;
using ShortURL.DomainModel.Entities;
using ShortURL.DomainModel.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortURL.Business.Entities
{
    public class ShortUrlBusiness : BaseBusiness<ShortUrl, ShortUrlDataAccess>
    {
        public ShortUrlBusiness(ShortUrlDataAccess da) : base(da) { }

        public ShortUrl MakeShortUrl(string originalUrl)
        {
            ShortUrl url = new ShortUrl
            {
                Original = originalUrl,
                Code = GetNewCode()
            };
            Save(url);
            return url;
        }

        public ShortUrl FindByCode(string code)
        {
            return DataAccess.GetByCode(code);
        }

        private string GetNewCode()
        {
            int length = ApplicationEnv.GetConfiguration().GetValue<int>(Constants.SHORT_URL_CODE_LENGTH);
            string code = TokenUtils.GenerateCode(length);
            while (DataAccess.GetByCode(code) != null)
            {
                code = TokenUtils.GenerateCode(length);
            }
            return code;
        }
    }
}
