using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;

namespace BBC.Test.PushBullet.Exception
{
    
    [Serializable]
    public class UserNotFoundException : ApiException
    {
        public UserNotFoundException()
        {
            this.StatusCode = StatusCodes.Status404NotFound;
        }

        public UserNotFoundException(string message) : base(message)
        {
            this.StatusCode = StatusCodes.Status404NotFound;
        }

        public UserNotFoundException(string message, System.Exception innerException) : base(message, innerException)
        {
            this.StatusCode = StatusCodes.Status404NotFound;
        }

        protected UserNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.StatusCode = StatusCodes.Status404NotFound;
        }
    }
}
