using DBApi.Model.Chat;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBApi.Interface
{
    public interface IChatRoomService
    {
        Task<List<ChatRoom>> GetChatRoomsAsync();
        Task<List<ChatRoom>> GetChatRoomsAsync(int userId);
        Task<bool> AddChatRoomAsync(ChatRoom newChatRoom);
    }
}
