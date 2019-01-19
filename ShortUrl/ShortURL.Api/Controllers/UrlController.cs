using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShortURL.Api.DTO.Entities;
using ShortURL.Business.Entities;
using ShortURL.DomainModel;
using ShortURL.DomainModel.Exceptions;

namespace ShortURL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private ShortUrlBusiness ShortUrlBusiness;

        public UrlController(ShortUrlBusiness shortBusiness)
        {
            ShortUrlBusiness = shortBusiness;
        }

        [HttpPost]
        public ActionResult Post([FromBody] SaveShortUrlRequestDTO payload)
        {
            try
            {
                string code = ShortUrlBusiness.MakeShortUrl(payload.original).Code;
                payload.shortUrl = $"{ApplicationEnv.GetApiUrl(HttpContext)}/{code}";                
                return Ok(payload);
            }
            catch (ShortUrlException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}