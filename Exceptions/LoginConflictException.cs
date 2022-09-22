using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF.Exceptions
{
    public class LoginConflictException : Exception
    {
        public string access_token { get; } 
        public LoginConflictException()
        {
            
        }

        public LoginConflictException(string? access_token) : base(access_token)
        {
            this.access_token = access_token;
        }

        public LoginConflictException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected LoginConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
