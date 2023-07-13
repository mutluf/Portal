using MediatR;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Commands.Educations.DeleteEducation
{
    public class DeleteEducationHandler : IRequestHandler<DeleteEducationRequest>
    {
        private readonly IEducationRepository _educationRepository;

        public DeleteEducationHandler(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task<Unit> Handle(DeleteEducationRequest request, CancellationToken cancellationToken)
        {
            Education education = await _educationRepository.GetByIdAysnc(request.Id.ToString());
            _educationRepository.Delete(education);
            await _educationRepository.SaveAysnc();
            
            return Unit.Value;
        }
    }
}
