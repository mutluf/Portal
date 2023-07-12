using Portal.Application.Repositories;
using Portal.Domain.Entities;
using Portal.Persistence.Context;

namespace Portal.Persistence.Repositories
{
    public class WorkshopRepository : GenericRepository<Workshop>, IWorkshopRepository
    {
        public WorkshopRepository(PortalAPIDbContext context) : base(context)
        {
        }
    }
}
