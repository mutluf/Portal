using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.Commands.Users.ChangeRole;

namespace Portal.WebAPI.Controllers
{
    [Route("api/profiles")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProfilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole([FromBody] ChangeRoleRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
