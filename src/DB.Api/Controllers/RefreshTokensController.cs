using DB.Api.Application.Commands;
using DB.Api.Application.Models;
using DB.Api.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OCCBPackage;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DB.Api.Controllers
{
    public class RefreshTokensController : BaseApiController
    {
        private readonly IMediator _mediator;

        public RefreshTokensController(IMediator mediator) =>
            _mediator = mediator;

        [HttpPost]
        [SwaggerOperation(OperationId = nameof(AddRefreshTokenAsync))]
        [SwaggerResponse(StatusCodes.Status200OK, "Added", typeof(int))]
        public async Task<IActionResult> AddRefreshTokenAsync([FromBody, BindRequired]AddRefreshTokenCommand command)
        {
            var refreshTokenId = await _mediator.Send(command);
            return Ok(refreshTokenId);
        }

        [HttpGet("token/{Token}")]
        [SwaggerOperation(OperationId = nameof(GetRefreshTokenByTokenAsync))]
        [SwaggerResponse(StatusCodes.Status200OK, "Received", typeof(GetRefreshTokenByTokenQueryResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Received", typeof(ApiProblemDetails))]
        public async Task<IActionResult> GetRefreshTokenByTokenAsync([FromRoute]GetRefreshTokenByTokenQuery query)
        {
            var refreshToken = await _mediator.Send(query);

            if(refreshToken == default)
            {
                return NotFound();
            }

            return Ok(refreshToken);
        }
    }
}
