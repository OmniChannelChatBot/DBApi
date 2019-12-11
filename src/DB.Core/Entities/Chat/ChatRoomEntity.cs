using DB.Core.Entities.Identity;
using System;
using System.Collections.Generic;

namespace DB.Core.Entities.Chat
{
    public class ChatRoomEntity : BaseEntity
    {
        public string Name { get; set; }

        public DateTimeOffset Date { get; set; }

        public List<UserEntity> Users { get; set; }
    }
}
