using DBApi.Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBApi.Interface
{
    interface IUserService
    {
        Task<List<User>> GetUsersAsync(Guid roomGuid);
        Task<User> GetUserAsync(Guid userGuid);
        Task<User> CreateUserAsync(User user);
        Task<bool> AddUserToRoomAsync(Guid roomGuid, Guid userGuid);
    }
}
