using MediatR;

namespace DB.Api.Application.Commands
{
    public class CreateChatMessageCommand : IRequest<int>
    {
    }
}
