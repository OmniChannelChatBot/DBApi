using DBApi.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DBApi.Model.Chat
{
    public class ChatMessage
    {
        public Guid Guid { get; set; }

        public int Id { get; set; }

        public int ChatRoomId { get; set; }
        [Required]
        public string Text { get; set; }

        public MessageType Type { get; set; } = MessageType.text;

        [Required]
        public string UserName { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}
