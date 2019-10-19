//using DBApi.Data;
//using DBApi.Interface;
//using DBApi.Model.Chat;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace DBApi.Service
//{
//    public class MessageService : IMessageService
//    {
//        private readonly ApplicationDbContext _context;

//        public MessageService(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<ChatMessage>> GetMessagesAsync()
//        {
//            var messages = await _context.ChatMessages.ToListAsync<ChatMessage>();

//            return messages;
//        }

//        public async Task<List<ChatMessage>> GetMessagesForChatRoomAsync(Guid roomGuid)
//        {
//            var messagesForRoom = await _context.ChatMessages
//                                      .Where(m => m.Guid == roomGuid)
//                                               .ToListAsync<ChatMessage>();

//            return messagesForRoom;
//        }

//        public async Task<bool> AddMessageToRoomAsync(Guid roomGuid, ChatMessage message)
//        {
//            message.Guid = roomGuid;
//            message.Date = DateTimeOffset.Now;

//            _context.ChatMessages.Add(message);

//            var saveResults = await _context.SaveChangesAsync();

//            return saveResults > 0;
//        }
//    }
//}
