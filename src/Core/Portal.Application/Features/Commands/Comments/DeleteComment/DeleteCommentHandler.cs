using MediatR;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Commands.Comments.DeleteComment
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentRequest>
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Unit> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
            Comment comment = await _commentRepository.GetByIdAysnc(request.Id.ToString());
            _commentRepository.Delete(comment);
            await _commentRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}
