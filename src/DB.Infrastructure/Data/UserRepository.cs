using DB.Core.Entities.Chat;
using DB.Core.Entities.Identity;
using DB.Core.Exceptions;
using DB.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatBotDbContext _context;

        public UserRepository(ChatBotDbContext context) =>
            _context = context;

        public Task<IReadOnlyList<UserEntity>> GetListAsync(CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        public async Task<int> AddAsync(UserEntity entity, CancellationToken cancellationToken = default)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public Task UpdateAsync(UserEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Users.Update(entity);

            return _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users.FindAsync(id, cancellationToken);
            if (user != default)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync(cancellationToken);
            };
        }

        public Task<bool> AvailabilityUsernameAsync(string username, CancellationToken cancellationToken = default) =>
            _context.Users.AnyAsync(u => u.Username == username, cancellationToken);

        public async Task AddUserToRoomAsync(Guid roomGuid, int id, CancellationToken cancellationToken = default)
        {
            var chatRoom = await _context.ChatRooms.FirstOrDefaultAsync(cr => cr.Guid == roomGuid, cancellationToken);

            if (chatRoom != default)
            {
                var chatUserEntity = new ChatChannelEntity
                {
                    UserId = id,
                    ChatRoomId = chatRoom.Id
                };

                _context.ChatChannels.Add(chatUserEntity);

                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new DBException($"invalid roomGuid: {roomGuid}");
            }
        }

        public Task<UserEntity> GetUserAsync(string userName, string password, CancellationToken cancellationToken = default) =>
            _context.Users.FirstOrDefaultAsync(u => u.Username == userName && u.Password == password, cancellationToken);

        public async Task<UserEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            await _context.Users.FindAsync(id, cancellationToken);

        public Task<UserEntity> GetByUsernameAsync(string userName, CancellationToken cancellationToken = default) =>
            _context.Users.FirstOrDefaultAsync(u => u.Username == userName, cancellationToken);
    }
}
