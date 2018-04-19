using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BBC.Test.PushBullet.Model.Entity
{
    public class User
    {
        public User()
        {
            RegistrationDate = DateTime.UtcNow;
        }

        [Key]
        public string Username { get; set; }

        public string AccessToken { get; set; }

        public DateTime RegistrationDate { get; set; }

        public long MessageCount { get; set; }
    }
}
