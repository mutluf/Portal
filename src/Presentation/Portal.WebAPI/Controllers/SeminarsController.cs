using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.Commands.Seminars.CreateSeminar;
using Portal.Application.Features.Queries.Seminars.GetSeminarById;

namespace Portal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeminarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSeminarRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetSeminarByIdRequest request)
        {
            GetSeminarByIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
