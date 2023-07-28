using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.SurveyFeatures.Commands.Responses.CreateResponse;

namespace Portal.API.Controllers
{
    [Route("api/responses")]
    [ApiController]
    public class ResponsesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResponsesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateResponseRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
