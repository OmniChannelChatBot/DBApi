using MediatR;
using OCCBPackage.Mvc;

namespace DB.Api.Controllers
{
    public class MessangerController : BaseApiController
    {
        private readonly IMediator _mediator;

        public MessangerController(IMediator mediator) =>
            _mediator = mediator;
    }
}