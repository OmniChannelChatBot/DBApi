using DB.Core.Entities.Chat;
using DB.Core.Entities.Identity;
using DB.Core.Exceptions;
using DB.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatBotDbContext _context;

        public UserRepository(ChatBotDbContext context) =>
            _context = context;

        public async Task AddUserToRoomAsync(Guid roomGuid, int id)
        {
            var chatRoom = await _context.ChatRooms.FirstOrDefaultAsync(cr => cr.Guid == roomGuid);

            if (chatRoom != default)
            {
                var chatUserEntity = new ChatUserEntity
                {
                    UserId = id,
                    ChatRoomId = chatRoom.Id
                };

                _context.ChatUsers.Add(chatUserEntity);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new DBException($"invalid roomGuid: {roomGuid}");
            }
        }

        public Task<bool> CheckUserNameAsync(string userName) =>
            _context.Users.AnyAsync(u => u.Username == userName);

        public Task<bool> CheckUserAsync(string userName, string password) =>
            _context.Users.AnyAsync(u => u.Username == userName && u.Password == password);

        public Task<UserEntity> GetUserAsync(string userName, string password) =>
            _context.Users.FirstOrDefaultAsync(u => u.Username == userName && u.Password == password);

        public async Task<UserEntity> GetByIdAsync(int id) =>
            await _context.Users.FindAsync(id);

        public Task<IReadOnlyList<UserEntity>> GetListAsync() =>
            throw new NotImplementedException();

        public Task AddAsync(UserEntity entity)
        {
            _context.Users.Add(entity);

            return _context.SaveChangesAsync();
        }

        public Task UpdateAsync(UserEntity entity)
        {
            _context.Users.Update(entity);

            return _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != default)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            };
        }
    }
}
