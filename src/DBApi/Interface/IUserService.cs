using DBApi.Model.Enum;
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
        Task<User> CreateUserAsync(string firstName, string lastName,
            string email, string userName, string password, UserType userType = UserType.person);
        Task<bool> AddUserToRoomAsync(Guid roomGuid, Guid userGuid);
    }
}
