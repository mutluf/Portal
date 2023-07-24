using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.Commands.Seminars.CreateSeminar;
using Portal.Application.Features.Commands.Seminars.DeleteSeminar;
using Portal.Application.Features.Commands.Seminars.UpdateSeminar;
using Portal.Application.Features.Queries.Seminars.GetSeminarById;
using Portal.Application.Features.Queries.Seminars.GetSeminarParticipant;
using Portal.Application.Features.Queries.Seminars.GetSeminarParticipants;

namespace Portal.WebAPI.Controllers
{
    [Route("api/seminars")]
    [ApiController]
    [Authorize(Roles = "Organiser")]
    public class SeminarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeminarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}/participant/{name}")]
        public async Task<IActionResult> GetParticipant([FromRoute] int id, [FromRoute] string name)
        {
            var request = new GetSeminarParticipantRequest
            {
                Id = id,
                Word = name
            };
            var response = await _mediator.Send(request);
            return Ok(response);
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

        [HttpGet("{Id}/participants")]
        public async Task<IActionResult> GetParticipants([FromRoute] GetSeminarParticipantsRequest request)
        {
            GetSeminarParticipantsResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
