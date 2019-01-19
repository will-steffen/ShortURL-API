using System;
using System.Collections.Generic;
using System.Text;

namespace ShortURL.DomainModel.Exceptions
{
    public class ShortUrlException : Exception
    {
        public ShortUrlException() { }
        public ShortUrlException(string message) : base(message) { }
    }
}
