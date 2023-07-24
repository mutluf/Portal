using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.Commands.Seminars.UpdateSeminar;
using Portal.Application.Features.Commands.Workshops.CreateWorkshop;
using Portal.Application.Features.Commands.Workshops.DeleteWorkshop;
using Portal.Application.Features.Queries.Participants.GetAllParticipantsByWorkshopId;
using Portal.Application.Features.Queries.Workshops.GetWorkshopById;

namespace Portal.WebAPI.Controllers
{
    [Route("api/workshops")]
    [ApiController]
    //[Authorize(Roles = "Organiser")]
    public class WorkshopsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkshopsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWorkshopRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetWorkshopByIdRequest request)
        {
            GetWorkshopByIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteWorkshopRequest request)
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

        [HttpGet("{Id}/[action]")]
        public async Task<IActionResult> gets([FromRoute] GetParticipantsByWorkshopRequest request)
        {
            GetParticipantsByWorkshopResponse response =  await _mediator.Send(request);
            return Ok(response);
        }
    }
}
