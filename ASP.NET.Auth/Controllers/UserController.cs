using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ASP.NET.Auth.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UserController : ControllerBase
    { 
        private ILogger _logger;
        public UserController(ILogger logger) 
        {
            _logger = logger;

            logger.WriteEvent("Event message");
            logger.WriteError("Error message!!!");
        }

        [HttpGet]
        public User GetUser()
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                Login = "ivanov_i",
                Password = "121213",
                FirstName = "Иван",
                LastName = "Иванов",
                Email = "example@gmail.com"
            };
        }
    }
}
