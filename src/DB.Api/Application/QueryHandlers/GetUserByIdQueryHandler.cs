using DB.Api.Application.Models;
using DB.Api.Application.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Api.Application.QueryHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResponse>
    {
        public Task<GetUserByIdQueryResponse> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
