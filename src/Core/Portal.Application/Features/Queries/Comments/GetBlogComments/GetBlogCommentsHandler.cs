using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Queries.Comments.GetBlogComments
{
    public class GetBlogCommentsHandler : IRequestHandler<GetBlogCommentsRequest, GetBlogCommentssResponse>
    {

        private readonly IBlogRepository _blogRepository;

        public GetBlogCommentsHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<GetBlogCommentssResponse> Handle(GetBlogCommentsRequest request, CancellationToken cancellationToken)
        {
            Blog blog =  _blogRepository.Table.Include(c => c.Comments).FirstOrDefault();

            List<Comment> comments = new();

            foreach (var item in blog.Comments)
            {
                comments.Add(new()
                {
                    Content = item.Content,
                    UserId = item.UserId,
                });
            }


            return new()
            {
                Comments = comments,
            };
        }
    }
}
