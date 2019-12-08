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
    public class ChatRoomsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ChatRoomsController(IMediator mediator) =>
            _mediator = mediator;

        [HttpGet]
        [SwaggerOperation(OperationId = nameof(GetChatRoomList))]
        [SwaggerResponse(StatusCodes.Status200OK, "Received", typeof(IEnumerable<GetListChatRoomQueryResponse>))]
        public async Task<IActionResult> GetChatRoomList()
        {
            var chatRooms = await _mediator.Send(new GetChatRoomListQuery());
            return Ok(chatRooms);
        }

        [HttpGet("/user/{Id:int}")]
        [SwaggerOperation(OperationId = nameof(GetChatRoomByUserId))]
        [SwaggerResponse(StatusCodes.Status200OK, "Received", typeof(GetChatRoomByUserIdQueryResponse))]
        public async Task<IActionResult> GetChatRoomByUserId([FromRoute]GetChatRoomByUserIdQuery query)
        {
            var chatRoom = await _mediator.Send(query);
            return Ok(chatRoom);
        }

        [HttpPost]
        [SwaggerOperation(OperationId = nameof(CreateChatRoom))]
        [SwaggerResponse(StatusCodes.Status200OK, "Created", typeof(int))]
        public async Task<IActionResult> CreateChatRoom([FromBody, BindRequired]CreateChatRoomCommand command)
        {
            var chatRoomId = await _mediator.Send(command);
            return Ok(chatRoomId);
        }
    }
}
