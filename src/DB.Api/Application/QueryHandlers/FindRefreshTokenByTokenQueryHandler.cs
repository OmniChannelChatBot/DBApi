using AutoMapper;
using DB.Api.Application.Models;
using DB.Api.Application.Queries;
using DB.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Api.Application.QueryHandlers
{
    public class FindRefreshTokenByTokenQueryHandler : IRequestHandler<FindRefreshTokenByTokenQuery, FindRefreshTokenByTokenQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public FindRefreshTokenByTokenQueryHandler(IMapper mapper, IRefreshTokenRepository refreshTokenRepository)
        {
            _mapper = mapper;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<FindRefreshTokenByTokenQueryResponse> Handle(FindRefreshTokenByTokenQuery query, CancellationToken cancellationToken)
        {
            var refreshToken = await _refreshTokenRepository.FindByTokenAsync(query.Token, cancellationToken);
            return _mapper.Map<FindRefreshTokenByTokenQueryResponse>(refreshToken);
        }
    }
}
