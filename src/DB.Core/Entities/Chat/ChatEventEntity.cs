namespace DB.Core.Entities.Chat
{
    public class ChatEventEntity: BaseEntity
    {
        public int ChatRoomId { get; set; }
        public string Text { get; set; }
    }
}
