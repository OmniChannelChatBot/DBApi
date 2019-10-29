using DBApi.Model.Enum;
using Microsoft.AspNetCore.Identity;
using System;

namespace DBApi.Model.Identity
{
    public class User
    {
        /// <summary>
        /// For channel users
        /// </summary>
        public Guid Guid { get; set; } = Guid.NewGuid();

        /// <summary>
        /// For known users stored in database
        /// </summary>
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public DateTimeOffset UpdateDate { get; set; }

        public UserType UserType { get; set; } = UserType.person;
    }
}
