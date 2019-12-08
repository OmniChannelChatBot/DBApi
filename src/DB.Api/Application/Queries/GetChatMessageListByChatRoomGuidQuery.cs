using DB.Api.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace DB.Api.Application.Queries
{
    public class GetChatMessageListByChatRoomGuidQuery : IRequest<IEnumerable<GetChatMessageListByChatRoomGuidQueryResponse>>
    {
        public Guid Guid { get; set; }
    }
}
