using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Core.Entities.Identity
{
    public class RefreshTokenEntity : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public DateTimeOffset Expires { get; set; }

        public string RemoteIpAddress { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }
    }
}
