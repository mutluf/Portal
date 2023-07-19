using Portal.Application.Repositories;
using Portal.Domain.Entities;
using Portal.Persistence.Context;

namespace Portal.Persistence.Repositories
{
    public class ProfileRepository : GenericRepository<UserProfile>, IProfileRepository
    {
        public ProfileRepository(PortalAPIDbContext context) : base(context)
        {
        }
    }
}
