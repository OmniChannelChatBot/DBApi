using DB.Core.Entities.Chat;
using DB.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Infrastructure.Data
{
    public class ChatRoomRepository : IChatRoomRepository
    {
        private readonly ChatBotDbContext _context;

        public ChatRoomRepository(ChatBotDbContext context) =>
            _context = context;

        public async Task<IReadOnlyList<ChatRoomEntity>> GetChatRoomsAsync(int userId, CancellationToken cancellationToken = default) =>
            await _context.ChatRooms.Where(cr => cr.ChatChannel.Any(u => u.UserId == userId)).ToArrayAsync();

        public Task<ChatRoomEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        public async Task<IReadOnlyList<ChatRoomEntity>> GetListAsync(CancellationToken cancellationToken = default) =>
            await _context.ChatRooms.ToArrayAsync(cancellationToken);

        public Task<int> AddAsync(ChatRoomEntity entity, CancellationToken cancellationToken = default)
        {
            _context.ChatRooms.Add(entity);
            return _context.SaveChangesAsync(cancellationToken);
        }
        public Task UpdateAsync(ChatRoomEntity entity, CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        public Task DeleteAsync(ChatRoomEntity entity, CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();
    }
}
