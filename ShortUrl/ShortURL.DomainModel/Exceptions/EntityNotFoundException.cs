using System;
using System.Collections.Generic;
using System.Text;

namespace ShortURL.DomainModel.Exceptions
{
    public class EntityNotFoundException : ShortUrlException
    {
        public EntityNotFoundException() { }
        public EntityNotFoundException(string message) : base(message) { }
    }
}
