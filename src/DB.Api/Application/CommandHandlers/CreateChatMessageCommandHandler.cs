using DB.Api.Application.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Api.Application.CommandHandlers
{
    public class CreateChatMessageCommandHandler : IRequestHandler<CreateChatMessageCommand, int>
    {
        public Task<int> Handle(CreateChatMessageCommand command, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
