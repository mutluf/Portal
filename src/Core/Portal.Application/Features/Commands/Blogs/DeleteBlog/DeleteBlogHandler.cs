using MediatR;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Commands.Blogs.DeleteBlog
{
    public class DeleteBlogHandler : IRequestHandler<DeleteBlogRequest>
    {
        private readonly IBlogRepository _blogRepository;

        public DeleteBlogHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Unit> Handle(DeleteBlogRequest request, CancellationToken cancellationToken)
        {
            Blog blog = await _blogRepository.GetByIdAysnc(request.Id.ToString());
            _blogRepository.Delete(blog);
            await _blogRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}
