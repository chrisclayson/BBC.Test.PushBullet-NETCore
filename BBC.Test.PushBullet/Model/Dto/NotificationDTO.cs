using System;
using System.Runtime.Serialization;

namespace BBC.Test.PushBullet.Model.Dto
{
    [DataContract]
    public class NotificationDTO
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Body { get; set; }

        [DataMember]
        public string PushBulletId { get; set; }    
    }
}
