using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
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
        private ClickBusiness ClickBusiness;

        public UrlController(ShortUrlBusiness shortBusiness, ClickBusiness clickBusiness)
        {
            ShortUrlBusiness = shortBusiness;
            ClickBusiness = clickBusiness;
        }

        [HttpPost]
        public ActionResult Post([FromBody] SaveShortUrlRequestDTO payload)
        {
            try
            {
                ShortUrl shortUrl = ShortUrlBusiness.MakeShortUrl(payload.url, payload.userId);
                ShortUrlDTO dto = new ShortUrlDTO(shortUrl, ApplicationEnv.GetApiUrl(HttpContext));
                return Ok(dto);
            }
            catch(InvalidUrlException e)
            {
                e.Ship();
                return StatusCode((int)HttpStatusCode.NotAcceptable);
            }
            catch (ShortUrlException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("count/{code}")]
        public ActionResult GetCount(string code)
        {
            try
            {
                return Ok(ClickBusiness.CountClicksByCode(code));
            }
            catch (ShortUrlException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("last/{userId}")]
        public ActionResult GetLast(long userId)
        {
            try
            {
                string host = ApplicationEnv.GetApiUrl(HttpContext);
                return Ok(ShortUrlBusiness.GetLastByIdUser(userId).Select(x => new ShortUrlDTO(x, host)));
            }
            catch (ShortUrlException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("stats/{code}")]
        public ActionResult GetStats(string code)
        {
            try
            {
                string host = ApplicationEnv.GetApiUrl(HttpContext);
                ShortUrl url = ShortUrlBusiness.Stats(code);
                var dto = new ShortUrlDTO(url, host, fullData: true);
                dto.countClick = ClickBusiness.CountClicksByCode(code);
                return Ok(dto);
            }
            catch (ShortUrlException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("metadata-title/{code}")]
        public ActionResult GetMetadataTitle(string code)
        {
            try
            {
                WebClient x = new WebClient();
                string source = x.DownloadString(ShortUrlBusiness.FindByCode(code).Original);
                string title = Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
                return Ok(new { title });
            }
            catch (ShortUrlException e)
            {
                return BadRequest(e.Message);
            }
        }

        
    }
}
