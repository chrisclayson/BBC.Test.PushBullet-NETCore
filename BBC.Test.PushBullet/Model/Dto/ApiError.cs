using System;
using System.Runtime.Serialization;

namespace BBC.Test.PushBullet.Model.Dto
{
    [DataContract]
    public class ApiError
    {
        [DataMember(Name = "timestamp")]
        public DateTime TimeStamp { get; set; }

        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "path")]
        public string ErrorPath { get; set; }
    }
}
