using DB.Core.Entities.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Core.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task AddUserToRoomAsync(Guid roomGuid, int id, CancellationToken cancellationToken = default);

        Task<bool> AvailabilityUsernameAsync(string username, CancellationToken cancellationToken = default);

        Task<UserEntity> GetByUsernameAsync(string userName, CancellationToken cancellationToken = default);
    }
}
