using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ShortURL.Api.DTO.Entities;
using ShortURL.Business.Entities;
using ShortURL.DomainModel;
using ShortURL.DomainModel.Entities;
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
                ShortUrl shortUrl = ShortUrlBusiness.MakeShortUrl(payload.url);
                ShortUrlDTO dto = new ShortUrlDTO();
                dto.original = shortUrl.Original;
                dto.shortUrl = $"{ApplicationEnv.GetApiUrl(HttpContext)}/{shortUrl.Code}";
                return Ok(dto);
            }
            catch(InvalidUrlException e)
            {
                return StatusCode((int)HttpStatusCode.NotAcceptable);
            }
            catch (ShortUrlException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{url}")]
        public ActionResult Get(string url)
        {
            try
            {
                string code = ShortUrlBusiness.MakeShortUrl(url).Code;
                return Ok($"{ApplicationEnv.GetApiUrl(HttpContext)}/{code}");
            }
            catch (ShortUrlException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}