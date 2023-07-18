using MediatR;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Commands.Categories.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetByIdAysnc(request.Id.ToString());  
            _categoryRepository.Delete(category);
            await _categoryRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}
