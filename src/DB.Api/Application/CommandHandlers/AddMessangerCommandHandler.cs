using AutoMapper;
using DB.Api.Application.Commands;
using DB.Core.Entities.Messangers;
using DB.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Api.Application.CommandHandlers
{
    public class AddMessangerCommandHandler : IRequestHandler<AddMessangerCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IMessangerRepository _messangerRepository;

        public AddMessangerCommandHandler(IMapper mapper, IMessangerRepository messangerRepository)
        {
            _mapper = mapper;
            _messangerRepository = messangerRepository;
        }

        public Task<int> Handle(AddMessangerCommand command, CancellationToken cancellationToken)
        {
            var messangerEntity = _mapper.Map<MessangerEntity>(command);
            return _messangerRepository.AddAsync(messangerEntity, cancellationToken);
        }
    }
}
