using MediatR;
using SmartClean.Application.DTOs;

namespace SmartClean.Application.Features.Worksites.Queries.GetWorksiteById
{
    public class GetWorksiteByIdQuery : IRequest<WorksiteDto>
    {
        public string Id { get; set; } = string.Empty;
    }
}
