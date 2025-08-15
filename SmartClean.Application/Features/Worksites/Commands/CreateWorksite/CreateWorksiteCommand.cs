using MediatR;
using SmartClean.Application.DTOs;

namespace SmartClean.Application.Features.Worksites.Commands.CreateWorksite
{
    public class CreateWorksiteCommand : IRequest<WorksiteDto>
    {
        public CreateWorksiteDto Worksite { get; set; } = new();
    }
}
