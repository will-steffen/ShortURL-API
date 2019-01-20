using ShortURL.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURL.Api.DTO.Entities
{
    public class UserDTO
    {
        public long id { get; set; }

        public UserDTO() { }

        public UserDTO(User user)
        {
            id = user.Id;
        }
    }
}
