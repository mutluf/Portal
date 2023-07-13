using MediatR;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Commands.Workshops.DeleteWorkshop
{
    public class DeleteWorkshopHandler : IRequestHandler<DeleteWorkshopRequest>
    {
        private readonly IWorkshopRepository _workshopRepository;

        public DeleteWorkshopHandler(IWorkshopRepository workshopRepository)
        {
            _workshopRepository = workshopRepository;
        }

        public async Task<Unit> Handle(DeleteWorkshopRequest request, CancellationToken cancellationToken)
        {
            Workshop workshop = await _workshopRepository.GetByIdAysnc(request.Id.ToString());
            _workshopRepository.Delete(workshop);
            await _workshopRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}
