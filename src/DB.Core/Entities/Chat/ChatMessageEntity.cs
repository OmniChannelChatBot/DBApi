using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Core.Entities.Chat
{
    public class ChatMessageEntity : BaseEntity
    {
        [Required]
        public int ChatUserId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public ChatMessageType Type { get; set; }

        [Required]
        public DateTimeOffset CreateDate { get; set; }

        [ForeignKey(nameof(ChatUserId))]
        public ChatUserEntity ChatUser { get; set; }
    }
}
