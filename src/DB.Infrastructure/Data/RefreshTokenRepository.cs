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

        public Task DeleteAsync(int id, CancellationToken cancellationToken = default) =>
            throw new System.NotImplementedException();

        public Task<RefreshTokenEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            throw new System.NotImplementedException();

        public Task<RefreshTokenEntity> GetByTokenAsync(string token, CancellationToken cancellationToken = default) =>
            _context.RefreshTokens.FirstOrDefaultAsync(f => f.Token == token, cancellationToken);

        public Task<IReadOnlyList<RefreshTokenEntity>> GetListAsync(CancellationToken cancellationToken = default) =>
            throw new System.NotImplementedException();

        public Task UpdateAsync(RefreshTokenEntity entity, CancellationToken cancellationToken = default) =>
            throw new System.NotImplementedException();
    }
}
