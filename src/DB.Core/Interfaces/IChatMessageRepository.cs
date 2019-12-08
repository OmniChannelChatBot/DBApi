using DB.Core.Entities.Chat;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB.Core.Interfaces
{
    public interface IChatMessageRepository : IRepository<ChatMessageEntity>
    {
        Task<IReadOnlyList<ChatMessageEntity>> GetMessagesForChatRoomAsync(Guid roomGuid);
    }
}
