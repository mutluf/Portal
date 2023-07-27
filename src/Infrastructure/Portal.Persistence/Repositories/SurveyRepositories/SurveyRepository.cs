using Portal.Application.Repositories.SurveyRepositories;
using Portal.Domain.Entities.Survey;
using Portal.Persistence.Context;

namespace Portal.Persistence.Repositories
{
    public class SurveyRepository : GenericRepository<Survey>, ISurveyRepository
    {
        public SurveyRepository(PortalAPIDbContext context) : base(context)
        {
        }
    }
}
