using AutoMapper;
using MediatR;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Commands.Educations.UpdateEducation
{
    public class UpdateEducationHandler : IRequestHandler<UpdateEducationRequest, UpdateEducationResponse>
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;
        public UpdateEducationHandler(IEducationRepository educationRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public async Task<UpdateEducationResponse> Handle(UpdateEducationRequest request, CancellationToken cancellationToken)
        {
            Education education = _mapper.Map<Education>(request);
            _educationRepository.Update(education);
            await _educationRepository.SaveAysnc();

            return new()
            {
                Message = "Başarıyla güncellendi"
            };
        }
    }
}
