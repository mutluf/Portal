using Portal.Application.Repositories;
using Portal.Domain.Entities;
using Portal.Persistence.Context;

namespace Portal.Persistence.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(PortalAPIDbContext context) : base(context)
        {
        }
    }
}
