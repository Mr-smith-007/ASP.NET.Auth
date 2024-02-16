﻿using System.Collections.Generic;
using System;
using System.Linq;

namespace ASP.NET.Auth
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public UserRepository()
        {
            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Иван",
                LastName = "Иванов",
                Email = "example1@gmail.com",
                Password = "111111",
                Login = "ivanov",
                Role = new Role()
                {
                    Id = 1,
                    Name = "Администратор"
                }
            });

            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Петр",
                LastName = "Петров",
                Email = "example2@mail.ru",
                Password = "222222",
                Login = "petrov",
                Role = new Role()
                {
                    Id = 2,
                    Name = "Пользователь"
                }
            });

            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Сидор",
                LastName = "Сидоров",
                Email = "example3@yandex.ru",
                Password = "333333",
                Login = "sidorov",
                Role = new Role()
                {
                    Id = 3,
                    Name = "Пользователь"
                }
            });
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetByLogin(string login)
        {
            return _users.FirstOrDefault(v => v.Login == login);
        }
    }
}
