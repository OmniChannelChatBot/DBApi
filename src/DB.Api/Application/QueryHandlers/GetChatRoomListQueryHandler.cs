using DB.Api.Application.Models;
using DB.Api.Application.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Api.Application.QueryHandlers
{
    public class GetChatRoomListQueryHandler : IRequestHandler<GetChatRoomListQuery, IEnumerable<GetChatRoomListQueryResponse>>
    {
        public Task<IEnumerable<GetChatRoomListQueryResponse>> Handle(GetChatRoomListQuery query, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
