using System;
using Microsoft.EntityFrameworkCore;

namespace BBC.Test.PushBullet.Model
{
    
    public class Registration
    {
        public Registration()
        {

        }

        public string Username { get; set; }

        public string AccessToken { get; set; }

        public DateTime RegistrationDate { get; set;  }

        public long MessageCount { get; set; }
    }
}
