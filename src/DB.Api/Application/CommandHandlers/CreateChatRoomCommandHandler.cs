using DB.Api.Application.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Api.Application.CommandHandlers
{
    public class CreateChatRoomCommandHandler : IRequestHandler<CreateChatRoomCommand, int>
    {
        public Task<int> Handle(CreateChatRoomCommand command, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
