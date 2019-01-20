using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ShortURL.Api.DTO;
using ShortURL.Business.Entities;
using ShortURL.DomainModel;
using ShortURL.DomainModel.Entities;
using ShortURL.DomainModel.Exceptions;

namespace ShortURL.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private ShortUrlBusiness ShortUrlBusiness;

        public LinkController(ShortUrlBusiness shortBusiness)
        {
            ShortUrlBusiness = shortBusiness;
        }

        [HttpGet("{code}")]
        public ActionResult Get(string code)
        {
            try
            {
                ShortUrl url = ShortUrlBusiness.FindByCode(code);
                if(url != null)
                {
                    return Redirect(url.Original);
                }
                string redirect = ApplicationEnv.GetStringConfiguration(Constants.NOT_FOUND_REDIRECT_URL);
                if (ApplicationEnv.GetBoolConfiguration(Constants.NOT_FOUND_REDIRECT_INCLUDE_CODE))
                {
                    redirect += "/" + code;
                }
                return Redirect(redirect);
            }
            catch (ShortUrlException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
