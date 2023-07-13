using AutoMapper;
using MediatR;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Commands.Blogs.CreateBlog
{
    public class CreateBlogHandler : IRequestHandler<CreateBlogRequest>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;
        public CreateBlogHandler(IMapper mapper, IBlogRepository blogRepository)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
        }

        public async Task<Unit> Handle(CreateBlogRequest request, CancellationToken cancellationToken)
        {
            Blog blog = _mapper.Map<Blog>(request.Blog);

            await _blogRepository.AddAysnc(blog);
            await _blogRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}
