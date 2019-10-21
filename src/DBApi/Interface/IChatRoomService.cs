using DBApi.Model.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBApi.Interface
{
    public interface IChatRoomService
    {
        Task<List<ChatRoom>> GetChatRoomsAsync();
        Task<List<ChatRoom>> GetChatRoomsAsync(Guid userGuid);
        Task<bool> AddChatRoomAsync(ChatRoom newChatRoom);
    }
}
