using MediatR;

namespace Portal.Application.Features.Queries.Blogs.GetBlogById
{
    public class GetBlogByIdRequest : IRequest<GetBlogByIdResponse>
    {
        public int Id { get; set; }
    }
}
