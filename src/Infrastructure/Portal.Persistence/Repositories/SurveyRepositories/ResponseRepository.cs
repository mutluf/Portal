using Portal.Application.Repositories.SurveyRepositories;
using Portal.Domain.Entities.Survey;
using Portal.Persistence.Context;

namespace Portal.Persistence.Repositories
{
    public class ResponseRepository : GenericRepository<Response>, IResponseRepository
    {
        public ResponseRepository(PortalAPIDbContext context) : base(context)
        {
        }
    }
}
