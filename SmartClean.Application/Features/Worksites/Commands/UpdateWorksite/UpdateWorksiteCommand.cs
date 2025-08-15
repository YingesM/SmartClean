using MediatR;
using SmartClean.Application.DTOs;

namespace SmartClean.Application.Features.Worksites.Commands.UpdateWorksite
{
    public class UpdateWorksiteCommand : IRequest<WorksiteDto>
    {
        public UpdateWorksiteDto Worksite { get; set; } = new();
    }
}
