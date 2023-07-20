using AutoMapper;
using MediatR;
using Portal.Application.Features.Commands.Workshops.UpdateWorkshop;
using Portal.Application.Features.Workshops.UpdateWorkshop.UpdateEducation;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Workshops.UpdateWorkshop
{
    public class UpdateWorkshopHandler : IRequestHandler<UpdateWorkshopRequest, UpdateWorkshopResponse>
    {
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IMapper _mapper;
        public UpdateWorkshopHandler(IWorkshopRepository workshopRepository, IMapper mapper)
        {
            _workshopRepository = workshopRepository;
            _mapper = mapper;
        }

        public async Task<UpdateWorkshopResponse> Handle(UpdateWorkshopRequest request, CancellationToken cancellationToken)
        {
            Workshop workshop = _mapper.Map<Workshop>(request);
            _workshopRepository.Update(workshop);
            await _workshopRepository.SaveAysnc();

            return new()
            {
                Message = "Başarıyla güncellendi"
            };
        }
    }
}
