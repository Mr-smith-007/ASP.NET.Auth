using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.NET.Auth.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UserController : ControllerBase
    {
        private IMapper _mapper;
        private ILogger _logger;
        private IUserRepository _userRepository;
        public UserController(ILogger logger, IMapper mapper, IUserRepository userRepository) 
        {
            _logger = logger;
            _mapper = mapper;
            _userRepository = userRepository;

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

        [Authorize]
        [HttpGet]
        [Route("viewmodel")]
        public UserViewModel GetUserViewModel()
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Иван",
                LastName = "Иванов",
                Email = "ivan@gmail.com",
                Password = "11111122222qq",
                Login = "ivanov"
            };

            var userViewModel = _mapper.Map<UserViewModel>(user);
                        
            return userViewModel;
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<UserViewModel> Authenticate(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Некорректный запрос");

            var user = _userRepository.GetByLogin(login);

            if (user is null)
                throw new AuthenticationException("Пользователь не найден");

            if (user.Password != password)
                throw new AuthenticationException("Введен неверный пароль");

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims,
                "AppCookie", 
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return _mapper.Map<UserViewModel>(user);
        }
    }
}
