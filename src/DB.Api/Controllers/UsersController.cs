using DB.Api.Application.Commands;
using DB.Api.Application.Models;
using DB.Api.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DB.Api.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator) =>
            _mediator = mediator;

        [HttpPost]
        [SwaggerOperation(OperationId = nameof(CreateUser))]
        [SwaggerResponse(StatusCodes.Status200OK, "Created", typeof(int))]
        public async Task<IActionResult> CreateUser([FromBody, BindRequired]CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);

            return Ok(userId);
        }

        [HttpPut]
        [SwaggerOperation(OperationId = nameof(UpdateUser))]
        [SwaggerResponse(StatusCodes.Status200OK, "Updated")]
        public async Task<IActionResult> UpdateUser([FromBody, BindRequired]UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("{Id:int}")]
        [SwaggerOperation(OperationId = nameof(GetUserById))]
        [SwaggerResponse(StatusCodes.Status200OK, "Received", typeof(GetUserByIdQueryResponse))]
        public async Task<IActionResult> GetUserById([FromRoute]GetUserByIdQuery query)
        {
            var user = await _mediator.Send(query);
            return Ok(user);
        }

        [HttpDelete("{Id:int}")]
        [SwaggerOperation(OperationId = nameof(DeleteUser))]
        [SwaggerResponse(StatusCodes.Status200OK, "Deleted")]
        public async Task<IActionResult> DeleteUser([FromRoute]DeleteUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}