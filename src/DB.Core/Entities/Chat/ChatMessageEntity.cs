using System;

namespace DB.Core.Entities.Chat
{
    public class ChatMessageEntity : BaseEntity
    {
        public int ChatRoomId { get; set; }

        public Guid UserGuid { get; set; }

        public string UserName { get; set; }

        public string Text { get; set; }

        public ChatMessageType Type { get; set; } = ChatMessageType.Text;

        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
    }
}
