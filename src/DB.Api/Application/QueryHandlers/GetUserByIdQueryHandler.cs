using AutoMapper;
using DB.Api.Application.Models;
using DB.Api.Application.Queries;
using DB.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Api.Application.QueryHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var userEntity = await _userRepository.GetByIdAsync(query.Id, cancellationToken);
            return _mapper.Map<GetUserByIdQueryResponse>(userEntity);
        }
    }
}
