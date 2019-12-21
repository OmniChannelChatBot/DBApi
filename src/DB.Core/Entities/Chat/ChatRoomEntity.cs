using DB.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Core.Entities.Chat
{
    public class ChatRoomEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTimeOffset CreateDate { get; set; }

        public IReadOnlyList<UserEntity> Users { get; set; }
    }
}
