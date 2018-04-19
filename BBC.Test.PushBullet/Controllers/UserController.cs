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
    [Route("/api/v1/users")]
    public class UserController : Controller
    {

        private readonly UserService service;
        private readonly IMapper mapper;

        public UserController(UserService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public UserDTO[] GetAll()
        {
            return mapper.Map<UserDTO[]>(this.service.GetAll());
        }

        [HttpGet("/{username}")]
        public UserDTO Get(string username)
        {
            return mapper.Map<UserDTO>(this.service.Get(username));
        }

        [HttpPost]
        public UserDTO Add([FromBody] UserDTO user)
        {
            return mapper.Map<UserDTO>(this.service.Add(mapper.Map<User>(user)));
        }

    }
}
