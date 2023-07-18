using MediatR;

namespace Portal.Application.Features.Commands.Categories.CreateCategory
{
    public class CreateCategoryRequest : IRequest
    {
        public string Content { get; set; }
    }
}