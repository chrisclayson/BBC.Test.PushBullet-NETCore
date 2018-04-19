using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;

namespace BBC.Test.PushBullet.Exception
{
    [Serializable]
    public class UsernameAlreadyExistsException : ApiException
    {
        public UsernameAlreadyExistsException()
        {
            this.StatusCode = StatusCodes.Status400BadRequest;
        }

        public UsernameAlreadyExistsException(string message) : base(message)
        {
            this.StatusCode = StatusCodes.Status400BadRequest;
        }

        public UsernameAlreadyExistsException(string message, System.Exception innerException) : base(message, innerException)
        {
            this.StatusCode = StatusCodes.Status400BadRequest;
        }

        protected UsernameAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}