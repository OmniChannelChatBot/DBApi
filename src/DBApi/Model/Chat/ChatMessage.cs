using DBApi.Model.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace DBApi.Model.Chat
{
    public class ChatMessage
    {
        public ChatMessage(int chatRoomId, string text, string userName, Guid userGuid)
        {
            ChatRoomId = chatRoomId;
            Text = text;
            UserName = userName;
            UserGuid = userGuid;
        }

        public Guid Guid { get; set; } = Guid.NewGuid();

        public int Id { get; set; }

        public int ChatRoomId { get; set; }
        [Required]
        public string Text { get; set; }

        public MessageType Type { get; set; } = MessageType.text;

        [Required]
        public string UserName { get; set; }

        public Guid UserGuid { get; set; }

        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
    }
}
