using DB.Core.Entities.Chat;
using DB.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Infrastructure.Data
{
    public class ChatRoomRepository : IChatRoomRepository
    {
        private readonly ChatBotDbContext _context;

        public ChatRoomRepository(ChatBotDbContext context) =>
            _context = context;

        public async Task<IReadOnlyList<ChatRoomEntity>> GetChatRoomsAsync(int userId) =>
            await _context.ChatRooms.Where(cr => cr.Users.Any(u => u.Id == userId)).ToArrayAsync();

        public Task<ChatRoomEntity> GetByIdAsync(int id) =>
            throw new NotImplementedException();

        public async Task<IReadOnlyList<ChatRoomEntity>> GetListAsync() =>
            await _context.ChatRooms.ToArrayAsync();

        public Task AddAsync(ChatRoomEntity entity)
        {
            _context.ChatRooms.Add(entity);

            return _context.SaveChangesAsync();
        }
        public Task UpdateAsync(ChatRoomEntity entity) =>
            throw new NotImplementedException();

        public Task DeleteAsync(int id) =>
            throw new NotImplementedException();
    }
}
