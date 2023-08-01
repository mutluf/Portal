using MediatR;

namespace Portal.Application.Features.Commands.Comments.CreateComment
{
    public class CreateCommentRequest: IRequest
    {
        public string? Content { get; set; }
        public int? UserId { get; set; }
    }
}