using MediatR;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Commands.Seminars.DeleteSeminar
{
    public class DeleteSeminarHandler : IRequestHandler<DeleteSeminarRequest>
    {
        private readonly ISeminarRepository _seminarRepository;

        public DeleteSeminarHandler(ISeminarRepository seminarRepository)
        {
            _seminarRepository = seminarRepository;
        }

        public async Task<Unit> Handle(DeleteSeminarRequest request, CancellationToken cancellationToken)
        {
            Seminar seminar = await _seminarRepository.GetByIdAysnc(request.Id.ToString());
            _seminarRepository.Delete(seminar);
            await _seminarRepository.SaveAysnc();
            
            return Unit.Value;
        }
    }
}
