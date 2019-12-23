using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Core.Entities.Chat
{
    public class ChatMessageEntity : BaseEntity
    {
        [Required]
        public int ChatChannelId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public short Type { get; set; }

        [ForeignKey(nameof(ChatChannelId))]
        public ChatChannelEntity ChatChannel { get; set; }
    }
}
