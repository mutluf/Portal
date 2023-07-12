using Portal.Application.Repositories;
using Portal.Domain.Entities;
using Portal.Persistence.Context;

namespace Portal.Persistence.Repositories
{
    public class SeminarRepository : GenericRepository<Seminar>, ISeminarRepository
    {
        public SeminarRepository(PortalAPIDbContext context) : base(context)
        {
        }
    }
}
