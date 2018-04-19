using System;
using System.Runtime.Serialization;

namespace BBC.Test.PushBullet.Model.Dto
{
    [DataContract]
    public class UserDTO
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "accessToken")]
        public string AccessToken { get; set; }

        [DataMember(Name = "createTime")]
        public DateTime RegistrationDate { get; set; }

        [DataMember(Name = "numOfNotificationsPushed")]
        public long MessageCount { get; set; }
    }
}
