using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;

namespace BBC.Test.PushBullet.Exception
{
    public class ApiException : System.Exception
    { 
        public ApiException()
        {
            this.StatusCode = StatusCodes.Status500InternalServerError;
        }

        public ApiException(string message) : base(message)
        {
            this.StatusCode = StatusCodes.Status500InternalServerError;
        }

        public ApiException(string message, System.Exception innerException) : base(message, innerException)
        {
            this.StatusCode = StatusCodes.Status500InternalServerError;
        }

        protected ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.StatusCode = StatusCodes.Status500InternalServerError;
        }

        public int StatusCode { get; set; }

    }
}
