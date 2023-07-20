using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.Commands.Educations.UpdateEducation;
using Portal.Application.Features.Commands.Seminars.CreateSeminar;
using Portal.Application.Features.Commands.Seminars.DeleteSeminar;
using Portal.Application.Features.Commands.Seminars.UpdateSeminar;
using Portal.Application.Features.Queries.Seminars.GetSeminarById;

namespace Portal.WebAPI.Controllers
{
    [Route("api/seminars")]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetSeminarByIdRequest request)
        {
            GetSeminarByIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSeminarRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSeminarRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
