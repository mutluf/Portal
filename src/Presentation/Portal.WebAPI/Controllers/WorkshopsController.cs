using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.Commands.Seminars.UpdateSeminar;
using Portal.Application.Features.Commands.Workshops.CreateWorkshop;
using Portal.Application.Features.Commands.Workshops.DeleteWorkshop;
using Portal.Application.Features.Queries.Workshops.GetWorkshopById;
using Portal.Application.Features.Queries.Workshops.GetWorkshopParticipants;

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

        [HttpGet("{Id}/participants")]
        public async Task<IActionResult> GetParticipants([FromRoute] GetWorkshopParticipantsRequest request)
        {
            GetWorkshopParticipantsResponse response =  await _mediator.Send(request);
            return Ok(response);
        }
    }
}
