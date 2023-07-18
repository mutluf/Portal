using Portal.Application.Repositories;
using Portal.Domain.Entities;
using Portal.Persistence.Context;

namespace Portal.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(PortalAPIDbContext context) : base(context)
        {
        }
    }
}
