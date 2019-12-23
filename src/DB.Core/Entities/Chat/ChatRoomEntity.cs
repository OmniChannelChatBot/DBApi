using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Core.Entities.Chat
{
    public class ChatRoomEntity : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public List<ChatChannelEntity> ChatChannel { get; set; }
    }
}
