using DB.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Core.Entities.Chat
{
    public class ChatRoomEntity : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public DateTimeOffset CreateDate { get; set; }

        public List<UserEntity> Users { get; set; }

        public List<ChatMessageEntity> ChatMessages { get; set; }
    }
}
