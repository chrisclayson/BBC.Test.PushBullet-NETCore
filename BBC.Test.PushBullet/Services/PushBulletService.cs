using System;
using BBC.Test.PushBullet.Exception;
using BBC.Test.PushBullet.Model.Dto;
using BBC.Test.PushBullet.Model.Entity;
using BBC.Test.PushBullet.Model.PushBullet;
using RestSharp;

namespace BBC.Test.PushBullet.Services
{
    public class PushBulletService
    {
        public static string PUSH_BULLET_API_URL = "https://api.pushbullet.com/v2/pushes";
        public static string PUSH_BULLET_ACCESS_TOKEN_HEADER = "Access-Token";
        public static string PUSH_BULLET_IDENTITY_ATTR = "iden";
        public static string PUSH_BULLET_PUSH_TYPE_NOTE = "note";

        private UserService userService;

        public PushBulletService(UserService userService)
        {
            this.userService = userService;
        }


        public NotificationDTO Send(string username, NotificationDTO notification)
        {
            User user = userService.Get(username);
            notification.PushBulletId = this.sendNotification(user, notification);
            return notification;
        }

        private string sendNotification(User user, NotificationDTO notification)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri(PushBulletService.PUSH_BULLET_API_URL);

            RestRequest request = new RestRequest();

            Push push = new Push()
            {
                type = PushBulletService.PUSH_BULLET_PUSH_TYPE_NOTE,
                body = notification.Body,
                title = notification.Title
            };

            request.AddJsonBody(push);
            request.AddHeader(PushBulletService.PUSH_BULLET_ACCESS_TOKEN_HEADER, user.AccessToken);

            var result = client.Post<dynamic>(request);

            if ( result.StatusCode == System.Net.HttpStatusCode.OK )
            {
                return result.Data[PushBulletService.PUSH_BULLET_IDENTITY_ATTR];
            }
            else
            {
                throw new PushBulletException(String.Format("Error calling PushBullet: {0}", result.Data["error"]["message"]));
            }

        }
    }
}
