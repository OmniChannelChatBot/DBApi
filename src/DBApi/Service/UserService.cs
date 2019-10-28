using DBApi.Data;
using DBApi.Exception;
using DBApi.ExtensionMethod;
using DBApi.Interface;
using DBApi.Model.Enum;
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

        public async Task<bool> AddUserToRoomAsync(Guid roomGuid, int userId)
        {
            var room = await _context.ChatRooms.FirstOrDefaultAsync(cr => cr.Guid == roomGuid);

            if (room != null)
            {
                var user = await GetUserAsync(userId);
                room.Users.Add(user);
                var saveResults = await _context.SaveChangesAsync();

                return saveResults > 0;
            }
            else
            {
                throw new DBApiExection($"invalid roomGuid: {roomGuid}");
            }
        }

        public async Task<User> CreateUserAsync(string firstName, string lastName, 
            string email, string userName, string password, UserType userType = UserType.person)
        {
            var now = DateTimeOffset.Now;

            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Login = userName,
                Password = password,
                Guid = Guid.NewGuid(),
                CreateDate = now,
                UpdateDate = now,
                UserType = userType
            };

            user = await CreateUserAsync(user);

            // TODO: return not all fields
            return user.WithoutPassword();
        }

        public async Task<User> UpdateUserAsync(string firstName, string lastName,
            string email, string userName, string password, UserType userType = UserType.person)
        {
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Login = userName,
                Password = password,
                UpdateDate = DateTimeOffset.Now,
                UserType = userType
            };

            user = await UpdateUserAsync(user);

            // TODO: return not all fields
            return user.WithoutPassword();
        }

        private async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        private async Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                return user.WithoutPassword();
            }
            else
            {
                throw new DBApiExection($"invalid userId: {userId}");
            }
        }

        public async Task<bool> CheckUserNameAsync(string userName)
        {
            var exists = await _context.Users.AnyAsync(u => u.Login == userName);

            return exists;
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
                throw new DBApiExection($"invalid roomGuid: {roomGuid}");
            }
        }

        public async Task<bool> DeleteAsync(int userId)
        {
            bool result = false;
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();

                result = true;
            }

            return result;
        }
    }
}
