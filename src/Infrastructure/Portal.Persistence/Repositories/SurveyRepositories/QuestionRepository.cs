using Portal.Application.Repositories.SurveyRepositories;
using Portal.Domain.Entities.Survey;
using Portal.Persistence.Context;

namespace Portal.Persistence.Repositories
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(PortalAPIDbContext context) : base(context)
        {
        }
    }
}
