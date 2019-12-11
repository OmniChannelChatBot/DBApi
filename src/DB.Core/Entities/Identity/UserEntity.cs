﻿using System;

namespace DB.Core.Entities.Identity
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Password { get; set; }
        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public UserType UserType { get; set; } = UserType.Person;

        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
    }
}
