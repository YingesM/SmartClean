using AutoMapper;
using MediatR;
using SmartClean.Application.DTOs;
using SmartClean.Core.Interfaces;

namespace SmartClean.Application.Features.Worksites.Queries.GetAllWorksites
{
    public class GetAllWorksitesQueryHandler : IRequestHandler<GetAllWorksitesQuery, IEnumerable<WorksiteDto>>
    {
        private readonly IWorksiteRepository _worksiteRepository;
        private readonly IMapper _mapper;

        public GetAllWorksitesQueryHandler(IWorksiteRepository worksiteRepository, IMapper mapper)
        {
            _worksiteRepository = worksiteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorksiteDto>> Handle(GetAllWorksitesQuery request, CancellationToken cancellationToken)
        {
            var worksites = await _worksiteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<WorksiteDto>>(worksites);
        }
    }
}
