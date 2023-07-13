using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.Commands.Workshops.CreateWorkshop;
using Portal.Application.Features.Commands.Workshops.DeleteWorkshop;
using Portal.Application.Features.Queries.Workshops.GetWorkshopById;

namespace Portal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetWorkshopByIdRequest request)
        {
            GetWorkshopByIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteWorkshopRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
