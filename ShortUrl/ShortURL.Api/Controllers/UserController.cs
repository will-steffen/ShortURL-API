using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class UserController : ControllerBase
    {
        private UserBusiness UserBusiness;

        public UserController(UserBusiness userBusiness)
        {
            UserBusiness = userBusiness;
        }

        [HttpGet]
        public ActionResult Get()
        {
            User user = UserBusiness.RequestNewUser(ApplicationEnv.GetClientIP(HttpContext));
            return Ok(new UserDTO(user));
        }

        [HttpGet("valid/{id}")]
        public ActionResult GetIsValidId(long id)
        {
            try
            {
                User user = UserBusiness.FindById(id);
                return Ok(true);
            }
            catch (ShortUrlException e)
            {
                e.Ship();
                return Ok(false);
            }
        }
    }
}
