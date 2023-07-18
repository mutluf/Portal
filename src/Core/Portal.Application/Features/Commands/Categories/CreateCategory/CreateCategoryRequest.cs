using MediatR;

namespace Portal.Application.Features.Commands.Categories.CreateCategory
{
    public class CreateCategoryRequest : IRequest
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}