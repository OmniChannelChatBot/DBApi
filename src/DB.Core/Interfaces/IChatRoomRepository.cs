using DB.Core.Entities.Chat;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB.Core.Interfaces
{
    public interface IChatRoomRepository: IRepository<ChatRoomEntity>
    {
        Task<IReadOnlyList<ChatRoomEntity>> GetChatRoomsAsync(int userId);
    }
}
