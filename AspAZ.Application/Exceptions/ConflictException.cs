using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Application.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string reason) : base(reason)
        {
            
        }
    }
}
