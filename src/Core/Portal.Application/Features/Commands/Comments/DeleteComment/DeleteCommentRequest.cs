using MediatR;

namespace Portal.Application.Features.Commands.Comments.DeleteComment
{
    public class DeleteCommentRequest : IRequest
    {
        public int Id { get; set; }
    }
}