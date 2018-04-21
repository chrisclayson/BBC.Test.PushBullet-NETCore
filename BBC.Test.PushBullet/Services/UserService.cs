using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using BBC.Test.PushBullet.Exception;
using BBC.Test.PushBullet.Model.Entity;

namespace BBC.Test.PushBullet.Services
{
    public class UserService
    {
        private ConcurrentDictionary<string, User> users = new ConcurrentDictionary<string, User>();

        public UserService()
        {
        }

        public User Add(User user)
        {
            if (this.users.ContainsKey(user.Username)) throw new UsernameAlreadyExistsException(String.Format("User {0} already exists!", user.Username));
            user.RegistrationDate = DateTime.UtcNow;
            user.MessageCount = 0;
            return this.users.GetOrAdd(user.Username, user);
        }

        public User Get(string username)
        {
            User user = null;
            if (this.users.TryGetValue(username, out user)) return user;
            throw new UserNotFoundException(String.Format("User {0} does not exist.", username));
        }

        public IEnumerable<User> GetAll()
        {
            return users.Values;
        }

        public void IncrementMessageCount(string username)
        {
            // lock (users[username])
            {
                users[username].MessageCount++;
            }
        }

        public int Count()
        {
            return users.Count;
        }

        public void Clear()
        {
            users.Clear();
        }
    }
}
