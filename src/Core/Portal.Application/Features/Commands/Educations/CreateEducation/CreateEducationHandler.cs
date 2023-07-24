using AutoMapper;
using MediatR;
using Portal.Application.Repositories;
using Portal.Domain.Entities;
using Portal.Domain.Entities.Users;

namespace Portal.Application.Features.Commands.Educations.CreateEducation
{
    public class CreateEducationHandler : IRequestHandler<CreateEducationRequest>
    {
        private readonly IMapper _mapper;
        private readonly IEducationRepository _educationRepository;
        public CreateEducationHandler(IMapper mapper, IEducationRepository educationRepository)
        {
            _mapper = mapper;
            _educationRepository = educationRepository;
        }

        public async Task<Unit> Handle(CreateEducationRequest request, CancellationToken cancellationToken)
        {
            Education education = _mapper.Map<Education>(request);

            List<Participant> participants = new();
            education.Participants = participants;

            await _educationRepository.AddAysnc(education);
            await _educationRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}
