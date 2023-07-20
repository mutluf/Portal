using AutoMapper;
using MediatR;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Commands.Workshops.CreateWorkshop
{
    public class CreateWorkshopHandler : IRequestHandler<CreateWorkshopRequest>
    {
        private readonly IMapper _mapper;
        private readonly IWorkshopRepository _workshopRepository;
        public CreateWorkshopHandler(IMapper mapper, IWorkshopRepository workshopRepository)
        {
            _mapper = mapper;
            _workshopRepository = workshopRepository;
        }

        public async Task<Unit> Handle(CreateWorkshopRequest request, CancellationToken cancellationToken)
        {
            Workshop workshop = _mapper.Map<Workshop>(request);
            List<Participant> workshops = new();
            workshop.Participants = workshops;


            await _workshopRepository.AddAysnc(workshop);
            await _workshopRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}
