using AutoMapper;
using MediatR;
using Portal.Application.DTOs;
using Portal.Application.Features.Queries.Workshops.GetWorkshopById;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Queries.Educations.GetEducationById
{
    public class GetWorkshopByIdHandler : IRequestHandler<GetWorkshopByIdRequest, GetWorkshopByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IWorkshopRepository _workshopRepository;
        public GetWorkshopByIdHandler(IMapper mapper, IWorkshopRepository workshopRepository)
        {
            _mapper = mapper;
            _workshopRepository = workshopRepository;
        }

        public async Task<GetWorkshopByIdResponse> Handle(GetWorkshopByIdRequest request, CancellationToken cancellationToken)
        {
            Workshop workshop = await _workshopRepository.GetByIdAysnc(request.Id.ToString());
            ActivityDTO result = _mapper.Map<ActivityDTO>(workshop);
            
            return new()
            {
                Workshop=result
            };
        }
    }
}
