using DB.Api.Application.Commands;
using DB.Api.Application.Models;
using DB.Api.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB.Api.Controllers
{
    public class ChatMessagesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ChatMessagesController(IMediator mediator) =>
            _mediator = mediator;

        [HttpGet]
        [SwaggerOperation(OperationId = nameof(GetChatMessageList))]
        [SwaggerResponse(StatusCodes.Status200OK, "Received", typeof(IEnumerable<GetChatMessageListQueryResponse>))]
        public async Task<IActionResult> GetChatMessageList()
        {
            var chatMessages = await _mediator.Send(new GetChatMessageListQuery());
            return Ok(chatMessages);
        }

        [HttpGet("/chat-room/{Guid}")]
        [SwaggerOperation(OperationId = nameof(GetChatMessageListByChatRoomGuid))]
        [SwaggerResponse(StatusCodes.Status200OK, "Received", typeof(IEnumerable<GetChatMessageListByChatRoomGuidQueryResponse>))]
        public async Task<IActionResult> GetChatMessageListByChatRoomGuid([FromRoute]GetChatMessageListByChatRoomGuidQuery query)
        {
            var chatMessages = await _mediator.Send(query);
            return Ok(chatMessages);
        }

        [HttpPost]
        [SwaggerOperation(OperationId = nameof(CreateChatMessage))]
        [SwaggerResponse(StatusCodes.Status200OK, "Created", typeof(int))]
        public async Task<IActionResult> CreateChatMessage([FromBody, BindRequired] CreateChatMessageCommand command)
        {
            var chatMessageId = await _mediator.Send(command);
            return Ok(chatMessageId);
        }
    }
}