using MediatR;
using SmartClean.Application.DTOs;

namespace SmartClean.Application.Features.Worksites.Queries.GetAllWorksites
{
    public class GetAllWorksitesQuery : IRequest<IEnumerable<WorksiteDto>>
    {
    }
}
