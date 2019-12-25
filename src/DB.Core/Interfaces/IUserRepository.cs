using DB.Core.Entities.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Core.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task AddUserToRoomAsync(Guid roomGuid, int id, CancellationToken cancellationToken = default);

        Task<bool> CheckUserNameAsync(string userName, CancellationToken cancellationToken = default);

        Task<bool> CheckUserAsync(string userName, string password, CancellationToken cancellationToken = default);

        Task<UserEntity> GetUserAsync(string userName, string password, CancellationToken cancellationToken = default);
    }
}
