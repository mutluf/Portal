using MediatR;

namespace Portal.Application.Features.Commands.Seminars.UpdateSeminar
{
    public class UpdateSeminarRequest : IRequest<UpdateSeminarResponse>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsPublic { get; set; } = true;
        public bool IsCanceled { get; set; } = false;
        public DateTime StartTime { get; set; }
    }
}