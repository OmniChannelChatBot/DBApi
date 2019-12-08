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

        public DateTimeOffset Date { get; set; }

        public List<UserEntity> Users { get; set; }
    }
}
