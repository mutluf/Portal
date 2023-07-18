using MediatR;

namespace Portal.Application.Features.Commands.Categories.DeleteCategory
{
    public class DeleteCategoryRequest : IRequest
    {
        public int Id { get; set; }
    }
}