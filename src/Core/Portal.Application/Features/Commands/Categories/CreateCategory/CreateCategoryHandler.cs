using AutoMapper;
using MediatR;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Commands.Categories.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request);
            await _categoryRepository.AddAysnc(category);
            await _categoryRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}
