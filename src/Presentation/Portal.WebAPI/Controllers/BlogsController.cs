using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.Commands.Blogs.CreateBlog;
using Portal.Application.Features.Commands.Blogs.DeleteBlog;
using Portal.Application.Features.Queries.Blogs.GetBlogById;

namespace Portal.WebAPI.Controllers
{
    [Route("api/blogs")]
    [ApiController]

    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetBlogByIdRequest request)
        {
            GetBlogByIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBlogRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
