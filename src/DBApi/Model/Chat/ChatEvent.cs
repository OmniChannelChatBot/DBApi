using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DBApi.Model.Chat
{
    public class ChatEvent
    {
        public Guid Guid { get; set; }

        public int Id { get; set; }

        public int ChatRoomId { get; set; }
        public string Text { get; set; }
    }
}
