using AutoMapper;
using MediatR;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Commands.Comments.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentRequest>
    {
        private readonly ICommentRepository _commentRepository;
        readonly IMapper _mapper;
        public CreateCommentHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
        {
            Comment comment = _mapper.Map<Comment>(request);
            await _commentRepository.AddAysnc(comment);
            await _commentRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}
