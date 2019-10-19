using DBApi.Model.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBApi.Interface
{
    public interface IMessageService
    {
        Task<List<ChatMessage>> GetMessagesAsync();
        Task<List<ChatMessage>> GetMessagesForChatRoomAsync(Guid roomId);
        Task<bool> AddMessageToRoomAsync(Guid roomId, ChatMessage message);
    }
}
