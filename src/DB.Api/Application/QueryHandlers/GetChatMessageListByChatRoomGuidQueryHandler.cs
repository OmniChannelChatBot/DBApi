using DB.Api.Application.Models;
using DB.Api.Application.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Api.Application.QueryHandlers
{
    public class GetChatMessageListByChatRoomGuidQueryHandler : IRequestHandler<GetChatMessageListByChatRoomGuidQuery, IEnumerable<GetChatMessageListByChatRoomGuidQueryResponse>>
    {
        public Task<IEnumerable<GetChatMessageListByChatRoomGuidQueryResponse>> Handle(GetChatMessageListByChatRoomGuidQuery query, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
