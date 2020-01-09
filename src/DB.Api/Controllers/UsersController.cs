using DB.Api.Application.Commands;
using DB.Api.Application.Models;
using DB.Api.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OCCBPackage.Mvc;
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
        [SwaggerOperation(OperationId = nameof(AddUserAsync))]
        [SwaggerResponse(StatusCodes.Status200OK, "Added", typeof(int))]
        public async Task<IActionResult> AddUserAsync([FromBody, BindRequired]AddUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return Ok(userId);
        }

        [HttpPut]
        [SwaggerOperation(OperationId = nameof(UpdateUserAsync))]
        [SwaggerResponse(StatusCodes.Status200OK, "Updated")]
        public async Task<IActionResult> UpdateUserAsync([FromBody, BindRequired]UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("{Id:int}")]
        [SwaggerOperation(OperationId = nameof(GetUserByIdAsync))]
        [SwaggerResponse(StatusCodes.Status200OK, "Received", typeof(GetUserByIdQueryResponse))]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute]GetUserByIdQuery query)
        {
            var user = await _mediator.Send(query);

            if (user == default)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpDelete("{Id:int}")]
        [SwaggerOperation(OperationId = nameof(DeleteUserAsync))]
        [SwaggerResponse(StatusCodes.Status200OK, "Deleted")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute]DeleteUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("availability/username/{Username}")]
        [SwaggerOperation(OperationId = nameof(AvailabilityUsernameAsync))]
        [SwaggerResponse(StatusCodes.Status200OK, "Available", typeof(bool))]
        public async Task<IActionResult> AvailabilityUsernameAsync([FromRoute]GetAvailabilityUsernameQuery query)
        {
            var availability = await _mediator.Send(query);
            return Ok(availability);
        }

        [HttpGet("username/{Username}")]
        [SwaggerOperation(OperationId = nameof(FindUserByUsernameAsync))]
        [SwaggerResponse(StatusCodes.Status200OK, "Received", typeof(FindUserByUsernameQueryResponse))]
        public async Task<IActionResult> FindUserByUsernameAsync([FromRoute]FindUserByUsernameQuery query)
        {
            var user = await _mediator.Send(query);
            return Ok(user);
        }
    }
}