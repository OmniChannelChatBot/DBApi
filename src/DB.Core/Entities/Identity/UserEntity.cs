using DB.Core.Entities.Chat;
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
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        public short Type { get; set; }

        public List<ChatChannelEntity> ChatChannel { get; set; }

        public List<RefreshTokenEntity> RefreshTokens { get; set; }
    }
}
