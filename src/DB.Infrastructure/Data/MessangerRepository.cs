using DB.Core.Entities.Messangers;
using DB.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Infrastructure.Data
{
    public class MessangerRepository : IMessangerRepository
    {
        private readonly ChatBotDbContext _context;

        public MessangerRepository(ChatBotDbContext context) =>
            _context = context;

        public Task<int> AddAsync(MessangerEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(MessangerEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<MessangerEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<MessangerEntity>> GetListAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MessangerEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
