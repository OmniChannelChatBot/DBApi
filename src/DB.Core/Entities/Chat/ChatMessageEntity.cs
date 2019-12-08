using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Core.Entities.Chat
{
    public class ChatMessageEntity : BaseEntity
    {
        public int ChatRoomId { get; set; }

        public Guid UserGuid { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Text { get; set; }

        public ChatMessageType Type { get; set; } = ChatMessageType.Text;

        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
    }
}
