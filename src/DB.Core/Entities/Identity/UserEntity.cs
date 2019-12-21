using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Core.Entities.Identity
{
    public class UserEntity : BaseEntity
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public short Type { get; set; }

        [Required]
        public DateTimeOffset CreateDate { get; set; }

        [Required]
        public DateTimeOffset UpdateDate { get; set; }
    }
}
