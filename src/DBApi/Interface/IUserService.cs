using DBApi.Model.Enum;
using DBApi.Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBApi.Interface
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync(Guid roomGuid);
        Task<User> GetUserAsync(int userId);
        Task<User> CreateUserAsync(string firstName, string lastName,
            string email, string userName, string password, UserType userType = UserType.person);

        Task<User> UpdateUserAsync(string firstName, string lastName,
            string email, string userName, string password, UserType userType = UserType.person);

        Task<bool> DeleteAsync(int userId);

        Task<bool> AddUserToRoomAsync(Guid roomGuid, int usrId);

        Task<bool> CheckUserNameAsync(string userName);
    }
}
