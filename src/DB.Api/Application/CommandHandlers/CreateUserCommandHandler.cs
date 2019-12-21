using AutoMapper;
using DB.Api.Application.Commands;
using DB.Core.Entities.Identity;
using DB.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Api.Application.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var userEntity = _mapper.Map<UserEntity>(command);
            return _userRepository.AddAsync(userEntity, cancellationToken);
        }
    }
}
