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
    public class DeleteMessangerCommandHandler : AsyncRequestHandler<DeleteMessangerCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMessangerRepository _messangerRepository;

        public DeleteMessangerCommandHandler(IMapper mapper, IMessangerRepository messangerRepository)
        {
            _mapper = mapper;
            _messangerRepository = messangerRepository;
        }

        protected override Task Handle(DeleteMessangerCommand command, CancellationToken cancellationToken)
        {
            var messangerEntity = _mapper.Map<MessangerEntity>(command);
            return _messangerRepository.DeleteAsync(messangerEntity, cancellationToken);
        }
    }
}
