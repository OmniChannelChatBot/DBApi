using DBApi.Data;
using DBApi.Interface;
using DBApi.Model.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBApi.Service
{
    public class UserService : IUserService
    {
        private readonly DBApiContext _context;

        public UserService(DBApiContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUserToRoomAsync(Guid roomGuid, Guid userGuid)
        {
            var room = await _context.ChatRooms.FirstOrDefaultAsync(cr => cr.Guid == roomGuid);

            if (room != null)
            {
                var user = await GetUserAsync(userGuid);
                room.Users.Add(user);
                var saveResults = await _context.SaveChangesAsync();

                return saveResults > 0;
            }
            else
            {
                //TODO: create UserServiceException class
                throw new Exception($"invalid roomGuid: {roomGuid}");
            }
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUserAsync(Guid userGuid)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Guid == userGuid);

            if (user != null)
            {
                return user;
            }
            else
            {
                //TODO: create UserServiceException class
                throw new Exception($"invalid userGuid: {userGuid}");
            }
        }

        public async Task<List<User>> GetUsersAsync(Guid roomGuid)
        {
            var chatRoom = await _context.ChatRooms
                .Include(cr => cr.Users)
                .FirstOrDefaultAsync(m => m.Guid == roomGuid);

            if (chatRoom != null)
            {
                var users = chatRoom.Users.ToList();

                return users;
            }
            else
            {
                //TODO: create UserServiceException class
                throw new Exception($"invalid roomGuid: {roomGuid}");
            }
        }
    }
}
