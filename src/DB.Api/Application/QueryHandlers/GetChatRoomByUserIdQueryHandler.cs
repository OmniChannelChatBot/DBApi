using DB.Api.Application.Models;
using DB.Api.Application.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Api.Application.QueryHandlers
{
    public class GetChatRoomByUserIdQueryHandler : IRequestHandler<GetChatRoomByUserIdQuery, GetChatRoomByUserIdQueryResponse>
    {
        public Task<GetChatRoomByUserIdQueryResponse> Handle(GetChatRoomByUserIdQuery query, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
