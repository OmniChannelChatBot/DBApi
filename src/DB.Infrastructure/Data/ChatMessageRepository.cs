using DB.Core.Entities.Chat;
using DB.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Infrastructure.Data
{
    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly ChatBotDbContext _context;

        public ChatMessageRepository(ChatBotDbContext context) =>
            _context = context;

        public async Task<IReadOnlyList<ChatMessageEntity>> GetMessagesForChatRoomAsync(Guid roomGuid) =>
            await _context.ChatMessages.Where(m => m.Guid == roomGuid).ToArrayAsync();

        public Task<ChatMessageEntity> GetByIdAsync(int id) =>
            throw new NotImplementedException();

        public async Task<IReadOnlyList<ChatMessageEntity>> GetListAsync() =>
            await _context.ChatMessages.ToArrayAsync();

        public Task AddAsync(ChatMessageEntity entity)
        {
            _context.ChatMessages.Add(entity);

            return _context.SaveChangesAsync();
        }

        public Task UpdateAsync(ChatMessageEntity entity) =>
            throw new NotImplementedException();

        public Task DeleteAsync(int id) =>
            throw new NotImplementedException();
    }
}
