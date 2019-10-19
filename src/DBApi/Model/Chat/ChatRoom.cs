using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DBApi.Model.Chat
{
    public class ChatRoom
    {
        public Guid Guid { get; set; }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTimeOffset Date { get; set; }

    }
}
