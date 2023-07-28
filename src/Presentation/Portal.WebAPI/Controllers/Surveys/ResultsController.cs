using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.SurveyFeatures.Queries.Results;

namespace Portal.API.Controllers
{
    [Route("api/results")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResultsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}/result")]
        public async Task<IActionResult> Get([FromRoute]GetResultByIdRequest request)
        {
            GetResultByIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
