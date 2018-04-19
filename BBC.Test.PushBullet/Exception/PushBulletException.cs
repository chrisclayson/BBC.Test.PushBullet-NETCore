using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;

namespace BBC.Test.PushBullet.Exception
{
    public class PushBulletException : ApiException
    { 
        public PushBulletException()
        {
            this.StatusCode = StatusCodes.Status500InternalServerError;
        }

        public PushBulletException(string message) : base(message)
        {
            this.StatusCode = StatusCodes.Status500InternalServerError;
        }

        public PushBulletException(string message, System.Exception innerException) : base(message, innerException)
        {
            this.StatusCode = StatusCodes.Status500InternalServerError;
        }

        protected PushBulletException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
