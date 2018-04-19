using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BBC.Test.PushBullet.Exception;
using BBC.Test.PushBullet.Model.Entity;
using BBC.Test.PushBullet.Services;
using Xunit;

namespace BBC.Test.PushBullet.Tests
{
    public class UserServiceTests
    {
        void HandleAction()
        {
        }


        private readonly UserService userService;

        public UserServiceTests()
        {
            this.userService = new UserService();
        }

        [Fact]
        public void AddUserSucceeds()
        {
            userService.Clear();
            User u1 = new User
            {
                Username = "Test1",
                AccessToken = "accessToken"
            };

            userService.Add(u1);

            User u2 = userService.Get("Test1");

            Assert.NotNull(u2);
            Assert.Equal(u1.Username, u2.Username);
            Assert.Equal(u1.AccessToken, u2.AccessToken);
            Assert.NotNull(u2.RegistrationDate);
            Assert.Equal(0, u2.MessageCount);
        }

        [Fact]
        public void AddDuplicateUserFailsAndThrowsUsernameAlreadyExistsException()
        {
            userService.Clear();
            User u1 = new User
            {
                Username = "Test1",
                AccessToken = "accessToken"
            };

            userService.Add(u1);

            User u2 = new User
            {
                Username = "Test1",
                AccessToken = "accessToken"
            };

            Assert.Throws<UsernameAlreadyExistsException>(() => userService.Add(u2));
        }

        [Fact]
        public void IncrementCountTests()
        {
            userService.Clear();
            User u1 = new User
            {
                Username = "Test1",
                AccessToken = "accessToken"
            };

            userService.Add(u1);

            userService.IncrementMessageCount("Test1");

            u1 = userService.Get("Test1");
            Assert.Equal(1, u1.MessageCount);

            userService.IncrementMessageCount("Test1");

            u1 = userService.Get("Test1");
            Assert.Equal(2, u1.MessageCount);

        }

        [Theory]
        [InlineData(1000)]
        [InlineData(2000)]
        [InlineData(10000)]
        [InlineData(500000)]
        [InlineData(1000000)]
        public void ConcurrentIncrementCountTests(int concurrentThreads)
        {
            Task[] tasks = new Task[concurrentThreads];
            userService.Clear();
            User u1 = new User
            {
                Username = "Test1",
                AccessToken = "accessToken"
            };

            userService.Add(u1);

            for (int i = 0; i < concurrentThreads; i++ )
            {
                tasks[i] = Task.Run(() => userService.IncrementMessageCount("Test1"));
            }
            Task.WaitAll(tasks);

            u1 = userService.Get("Test1");
            Assert.Equal(concurrentThreads, u1.MessageCount);
        }

        [Fact]
        public void AddTenUsersSucceed()
        {
            userService.Clear();

            for (int i = 1; i <= 10; i++)
            {
                User u = new User
                {
                    Username = String.Format("Test{0}", i),
                    AccessToken = "accessToken"
                };

                userService.Add(u);
            }
            Assert.Equal(userService.Count(), 10);

        }

        [Fact]
        public void ClearSucceeds()
        {
            for (int i = 1; i <= 10; i++)
            {
                User u = new User
                {
                    Username = String.Format("Test{0}", i),
                    AccessToken = "accessToken"
                };

                userService.Add(u);
            }
            userService.Clear();
            Assert.Equal(userService.Count(), 0);
        }
    }
}
