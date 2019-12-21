﻿using DB.Core.Entities.Identity;
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

        public async Task AddUserToRoomAsync(Guid roomGuid, int id, CancellationToken cancellationToken = default)
        {
            var chatRoom = await _context.ChatRooms.FirstOrDefaultAsync(cr => cr.Guid == roomGuid, cancellationToken);

            if (chatRoom != default)
            {
                var user = await GetByIdAsync(id);

                chatRoom.Users.Add(user);

                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new DBException($"invalid roomGuid: {roomGuid}");
            }
        }

        public Task<bool> CheckUserNameAsync(string userName, CancellationToken cancellationToken = default) =>
            _context.Users.AnyAsync(u => u.Username == userName, cancellationToken);

        public Task<bool> CheckUserAsync(string userName, string password, CancellationToken cancellationToken = default) =>
            _context.Users.AnyAsync(u => u.Username == userName && u.Password == password, cancellationToken);

        public Task<UserEntity> GetUserAsync(string userName, string password, CancellationToken cancellationToken = default) =>
            _context.Users.FirstOrDefaultAsync(u => u.Username == userName && u.Password == password, cancellationToken);

        public async Task<IReadOnlyList<UserEntity>> GetUsersAsync(Guid roomGuid, CancellationToken cancellationToken = default)
        {
            var chatRoom = await _context.ChatRooms
                .Include(cr => cr.Users)
                .FirstOrDefaultAsync(m => m.Guid == roomGuid, cancellationToken);

            return chatRoom?.Users?.ToArray() ??
                throw new DBException($"invalid roomGuid: {roomGuid}");
        }

        public async Task<UserEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            await _context.Users.FindAsync(id, cancellationToken);

        public Task<IReadOnlyList<UserEntity>> GetListAsync(CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        public async Task<int> AddAsync(UserEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Users.Add(entity);
            var d = await _context.SaveChangesAsync(cancellationToken);
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
    }
}