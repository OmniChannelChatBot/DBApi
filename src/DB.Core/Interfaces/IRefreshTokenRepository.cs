using DB.Core.Entities.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Core.Interfaces
{
    public interface IRefreshTokenRepository : IRepository<RefreshTokenEntity>
    {
        Task<RefreshTokenEntity> FindByTokenAsync(string token, CancellationToken cancellationToken = default);
    }
}
