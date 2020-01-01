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

        [HttpDelete]
        [SwaggerOperation(OperationId = nameof(DeleteRefreshTokenAsync))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Deleted")]
        public async Task<IActionResult> DeleteRefreshTokenAsync([FromBody, BindRequired]DeleteRefreshTokenCommand command)
        {
            await _mediator.Send(command);
            return Ok(default);
        }

        [HttpPatch]
        [SwaggerOperation(OperationId = nameof(UpdateRefreshTokenAsync))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Updated")]
        public async Task<IActionResult> UpdateRefreshTokenAsync([FromBody, BindRequired]UpdateRefreshTokenCommand command)
        {
            await _mediator.Send(command);
            return Ok(default);
        }

        [HttpGet("token/{Token}")]
        [SwaggerOperation(OperationId = nameof(FindRefreshTokenByTokenAsync))]
        [SwaggerResponse(StatusCodes.Status200OK, "Received", typeof(FindRefreshTokenByTokenQueryResponse))]
        public async Task<IActionResult> FindRefreshTokenByTokenAsync([FromRoute]FindRefreshTokenByTokenQuery query)
        {
            // TODO: Token приходит c экранированными символами, если они есть
            var refreshToken = await _mediator.Send(query);
            return Ok(refreshToken);
        }
    }
}
