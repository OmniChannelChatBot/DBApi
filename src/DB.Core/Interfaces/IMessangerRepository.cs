using DB.Core.Entities.Messangers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Core.Interfaces
{
    public interface IMessangerRepository : IRepository<MessangerEntity>
    {
        Task<IReadOnlyList<MessangerEntity>> GetByUserIdAsync(int id, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<MessangerEntity>> GetByCompanyIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
