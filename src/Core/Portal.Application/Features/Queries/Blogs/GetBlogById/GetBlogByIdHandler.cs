using AutoMapper;
using MediatR;
using Portal.Application.DTOs;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Queries.Blogs.GetBlogById
{
    public class GetBlogByIdHandler : IRequestHandler<GetBlogByIdRequest, GetBlogByIdResponse>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogByIdHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<GetBlogByIdResponse> Handle(GetBlogByIdRequest request, CancellationToken cancellationToken)
        {
            Blog blog = await _blogRepository.GetByIdAysnc(request.Id.ToString());

            BlogDTO result = _mapper.Map<BlogDTO>(blog);

            return new()
            {
                Blog = result
            };
        }
    }
}
