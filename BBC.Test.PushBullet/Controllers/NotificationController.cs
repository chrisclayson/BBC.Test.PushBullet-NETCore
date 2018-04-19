using System;
using BBC.Test.PushBullet.Model.Entity;
using BBC.Test.PushBullet.Model.Dto;
using BBC.Test.PushBullet.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BBC.Test.PushBullet.Filter;

namespace BBC.Test.PushBullet.Controllers
{
    [ApiExceptionFilter]
    [Route("/api/v1/notification")]
    public class NotificationController : Controller
    {

        private readonly UserService service;
        private readonly IMapper mapper;
        private readonly PushBulletService pushBulletService;

        public NotificationController(UserService service, IMapper mapper, PushBulletService pushBulletService)
        {
            this.service = service;
            this.mapper = mapper;
            this.pushBulletService = pushBulletService;
        }


        [HttpPost]
        [Route("{username}")]
        public NotificationDTO Get([FromRoute]string username, [FromBody] NotificationDTO notification)
        {
            notification = pushBulletService.Send(username, notification);
            service.IncrementMessageCount(username);
            return notification;
        }

    }
}
