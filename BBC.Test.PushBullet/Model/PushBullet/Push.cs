using System;
using System.Runtime.Serialization;

namespace BBC.Test.PushBullet.Model.PushBullet
{
    [DataContract]
    public class Push
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "body")]
        public string body { get; set; }
    }
}
