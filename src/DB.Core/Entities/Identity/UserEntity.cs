using DB.Core.Entities.Chat;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Core.Entities.Identity
{
    public class UserEntity : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string Username { get; set; }

        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        public UserType Type { get; set; }

        [Required]
        public DateTimeOffset CreateDate { get; set; }

        [Required]
        public DateTimeOffset UpdateDate { get; set; }

        public List<ChatUserEntity> ChatUsers { get; set; }
    }
}
