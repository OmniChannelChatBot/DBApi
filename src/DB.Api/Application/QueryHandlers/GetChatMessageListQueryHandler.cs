using DB.Api.Application.Models;
using DB.Api.Application.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Api.Application.QueryHandlers
{
    public class GetChatMessageListQueryHandler : IRequestHandler<GetChatMessageListQuery, IEnumerable<GetChatMessageListQueryResponse>>
    {
        public Task<IEnumerable<GetChatMessageListQueryResponse>> Handle(GetChatMessageListQuery query, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
