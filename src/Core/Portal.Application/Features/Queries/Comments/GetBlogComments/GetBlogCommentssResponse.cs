using Portal.Domain.Entities;

namespace Portal.Application.Features.Queries.Comments.GetBlogComments
{
    public class GetBlogCommentssResponse
    {
        public List<Comment> Comments { get; set; }
    }
}