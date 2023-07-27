using Portal.Application.Repositories.SurveyRepositories;
using Portal.Domain.Entities.Survey;
using Portal.Persistence.Context;

namespace Portal.Persistence.Repositories
{
    public class OptionRepository : GenericRepository<Option>, IOptionRepository
    {
        public OptionRepository(PortalAPIDbContext context) : base(context)
        {
        }
    }
}
