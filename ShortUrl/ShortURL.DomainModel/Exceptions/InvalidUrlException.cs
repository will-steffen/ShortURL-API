using System;
using System.Collections.Generic;
using System.Text;

namespace ShortURL.DomainModel.Exceptions
{
    public class InvalidUrlException : ShortUrlException
    {
        public InvalidUrlException() { }
        public InvalidUrlException(string message) : base(message) { }
    }
}
