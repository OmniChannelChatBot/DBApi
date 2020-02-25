using DB.Api.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OCCBPackage.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DB.Api.Controllers
{
    public class MessangerController : BaseApiController
    {
        private readonly IMediator _mediator;

        public MessangerController(IMediator mediator) =>
            _mediator = mediator;

        [HttpPost]
        [SwaggerOperation(OperationId = nameof(AddMessangerAsync))]
        [SwaggerResponse(StatusCodes.Status200OK, "Created", typeof(int))]
        public async Task<IActionResult> AddMessangerAsync([FromBody, BindRequired] AddMessangerCommand command)
        {
            var messangerId = await _mediator.Send(command);
            return Ok(messangerId);
        }

        [HttpDelete]
        [SwaggerOperation(OperationId = nameof(DeleteMessangerAsync))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Deleted")]
        public async Task<IActionResult> DeleteMessangerAsync([FromBody, BindRequired]DeleteMessangerCommand command)
        {
            await _mediator.Send(command);
            return Ok(default);
        }
    }
}