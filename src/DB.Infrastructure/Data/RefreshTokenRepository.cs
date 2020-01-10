using DB.Core.Entities.Identity;
using DB.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Infrastructure.Data
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ChatBotDbContext _context;

        public RefreshTokenRepository(ChatBotDbContext context) =>
            _context = context;

        public async Task<int> AddAsync(RefreshTokenEntity entity, CancellationToken cancellationToken = default)
        {
            await _context.RefreshTokens.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task UpdateAsync(RefreshTokenEntity entity, CancellationToken cancellationToken = default)
        {
            // TODO: Хитрость с частичным обновлением
            var emptyEntity = new RefreshTokenEntity { Id = entity.Id };

            _context.RefreshTokens
                .Attach(emptyEntity).CurrentValues
                .SetValues(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task DeleteAsync(RefreshTokenEntity entity, CancellationToken cancellationToken = default)
        {
            _context.RefreshTokens.Remove(entity);
            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task<RefreshTokenEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            throw new System.NotImplementedException();

        public Task<RefreshTokenEntity> FindByTokenAsync(string token, CancellationToken cancellationToken = default) =>
            _context.RefreshTokens.AsNoTracking().FirstOrDefaultAsync(f => f.Token == token, cancellationToken);

        public Task<IReadOnlyList<RefreshTokenEntity>> GetListAsync(CancellationToken cancellationToken = default) =>
            throw new System.NotImplementedException();
    }
}
