﻿using DB.Core.Entities.Identity;
using System;
using System.Threading.Tasks;

namespace DB.Core.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task AddUserToRoomAsync(Guid roomGuid, int id);

        Task<bool> CheckUserNameAsync(string userName);

        Task<bool> CheckUserAsync(string userName, string password);

        Task<UserEntity> GetUserAsync(string userName, string password);
    }
}
