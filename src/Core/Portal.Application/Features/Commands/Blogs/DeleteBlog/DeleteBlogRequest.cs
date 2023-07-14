using MediatR;

namespace Portal.Application.Features.Commands.Blogs.DeleteBlog
{
    public class DeleteBlogRequest: IRequest
    {
        public int Id { get; set; }
    }
}
