using AutoMapper;
using DB.Api.Application.Models;
using DB.Api.Application.Queries;
using DB.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Api.Application.QueryHandlers
{
    public class FindUserByUsernameQueryHandler : IRequestHandler<FindUserByUsernameQuery, FindUserByUsernameQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public FindUserByUsernameQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<FindUserByUsernameQueryResponse> Handle(FindUserByUsernameQuery query, CancellationToken cancellationToken)
        {
            var userEntity = await _userRepository.GetByUsernameAsync(query.Username, cancellationToken);
            return _mapper.Map<FindUserByUsernameQueryResponse>(userEntity);
        }
    }
}
