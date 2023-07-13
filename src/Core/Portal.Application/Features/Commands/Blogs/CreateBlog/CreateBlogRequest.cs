using MediatR;
using Portal.Application.DTOs;

namespace Portal.Application.Features.Commands.Blogs.CreateBlog
{
    public class CreateBlogRequest : IRequest
    {
        public BlogDTO Blog { get; set; }
    }
}
