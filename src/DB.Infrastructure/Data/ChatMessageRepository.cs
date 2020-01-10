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
    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly ChatBotDbContext _context;

        public ChatMessageRepository(ChatBotDbContext context) =>
            _context = context;

        public async Task<IReadOnlyList<ChatMessageEntity>> GetMessagesForChatRoomAsync(Guid roomGuid, CancellationToken cancellationToken = default) =>
            await _context.ChatMessages.Where(m => m.Guid == roomGuid).ToArrayAsync(cancellationToken);

        public Task<ChatMessageEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        public async Task<IReadOnlyList<ChatMessageEntity>> GetListAsync(CancellationToken cancellationToken = default) =>
            await _context.ChatMessages.ToArrayAsync(cancellationToken);

        public Task<int> AddAsync(ChatMessageEntity entity, CancellationToken cancellationToken = default)
        {
            _context.ChatMessages.Add(entity);

            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task UpdateAsync(ChatMessageEntity entity, CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        public Task DeleteAsync(ChatMessageEntity entity, CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();
    }
}
