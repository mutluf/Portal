using MediatR;

namespace Portal.Application.Features.Queries.Comments.GetBlogComments
{
    public class GetBlogCommentsRequest : IRequest<GetBlogCommentssResponse>
    {
        public int Id { get; set; }
    }
}