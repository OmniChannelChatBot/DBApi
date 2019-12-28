using AutoMapper;
using DB.Api.Application.Models;
using DB.Api.Application.Queries;
using DB.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Api.Application.QueryHandlers
{
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, GetUserByUsernameQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserByUsernameQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<GetUserByUsernameQueryResponse> Handle(GetUserByUsernameQuery query, CancellationToken cancellationToken)
        {
            var userEntity = await _userRepository.GetByUsernameAsync(query.Username, cancellationToken);
            return _mapper.Map<GetUserByUsernameQueryResponse>(userEntity);
        }
    }
}
