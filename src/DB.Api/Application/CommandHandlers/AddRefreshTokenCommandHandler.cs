using AutoMapper;
using DB.Api.Application.Commands;
using DB.Core.Entities.Identity;
using DB.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Api.Application.CommandHandlers
{
    public class AddRefreshTokenCommandHandler : IRequestHandler<AddRefreshTokenCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AddRefreshTokenCommandHandler(IMapper mapper, IRefreshTokenRepository refreshTokenRepository)
        {
            _mapper = mapper;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public Task<int> Handle(AddRefreshTokenCommand command, CancellationToken cancellationToken)
        {
            var refreshTokenEntity = _mapper.Map<RefreshTokenEntity>(command);
            return _refreshTokenRepository.AddAsync(refreshTokenEntity, cancellationToken);
        }
    }
}
