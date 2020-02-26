using DB.Core.Entities.Messangers;
using DB.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _context.Messangers.AddAsync(entity, cancellationToken);

            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task DeleteAsync(MessangerEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Messangers.Remove(entity);
            return _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<MessangerEntity>> GetByCompanyIdAsync(int companyId, CancellationToken cancellationToken = default) => 
            await _context.Messangers.Where(u => u.CompanyId == companyId).ToArrayAsync(cancellationToken);

        public Task<MessangerEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<MessangerEntity>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default) =>
            await _context.Messangers.Where(u => u.UserId == userId).ToArrayAsync();


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
