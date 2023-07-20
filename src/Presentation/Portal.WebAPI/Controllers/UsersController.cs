

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.Commands.Users.CreateUser;
using Portal.Application.Features.Commands.Users.LoginUser;

namespace FLoraAPI.API.Controllers
{
    [Route("api/users")]
    [ApiController]
   
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserRequest request)
        {
            CreateUserResponse response =await _mediator.Send(request);
            return Ok(response);
        }
    
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserRequest request)
        {
            LoginUserResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
