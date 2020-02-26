using DB.Core.Entities.Chat;
using DB.Core.Entities.Identity;
using DB.Core.Entities.Messangers;
using Microsoft.EntityFrameworkCore;

namespace DB.Infrastructure.Data
{
    public class ChatBotDbContext : DbContext
    {
        public ChatBotDbContext(DbContextOptions<ChatBotDbContext> options)
            : base(options)
        {
        }

        public DbSet<ChatRoomEntity> ChatRooms { get; set; }

        public DbSet<ChatChannelEntity> ChatChannels { get; set; }

        public DbSet<ChatMessageEntity> ChatMessages { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }

        public DbSet<MessangerEntity> Messangers { get; set; }
    }
}
