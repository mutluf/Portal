using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.Commands.Roles.CreateRole;
using Portal.Application.Features.Commands.Roles.DeleteRole;
using Portal.Application.Features.Commands.Roles.UpdateRole;
using Portal.Application.Features.Queries.Roles.GetAllRoles;
using Portal.Application.Features.Queries.Roles.GetRoleById;

namespace Portal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles(GetAllRolesRequest request)
        {
            GetAllRolesResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetRole([FromRoute] GetRoleByIdRequest request)
        {
            GetRoleByIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteRole([FromRoute] DeleteRoleRequest request)
        {
            DeleteRoleResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateRole([FromBody ,FromRoute] UpdateRoleRequest request)
        {
            UpdateRoleResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            CreateRoleResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
