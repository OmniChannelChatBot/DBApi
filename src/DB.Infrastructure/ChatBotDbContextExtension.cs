using DB.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DB.Infrastructure
{
    public static class ChatBotDbContextExtension
    {
        public static IApplicationBuilder UpdateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var chatBotDbContext = serviceScope.ServiceProvider.GetService<ChatBotDbContext>())
                {
                    chatBotDbContext.Database.Migrate();
                }
            }

            return app;
        }
    }
}
