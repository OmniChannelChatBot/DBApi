using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Core.Entities.Chat
{
    public class ChatMessageEntity : BaseEntity
    {
        [Required]
        public int ChatRoomId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public ChatMessageType Type { get; set; }

        [Required]
        public DateTimeOffset CreateDate { get; set; }
    }
}
