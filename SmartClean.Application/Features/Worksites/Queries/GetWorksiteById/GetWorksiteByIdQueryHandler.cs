using AutoMapper;
using MediatR;
using SmartClean.Application.DTOs;
using SmartClean.Application.Exceptions;
using SmartClean.Core.Interfaces;

namespace SmartClean.Application.Features.Worksites.Queries.GetWorksiteById
{
    public class GetWorksiteByIdQueryHandler : IRequestHandler<GetWorksiteByIdQuery, WorksiteDto>
    {
        private readonly IWorksiteRepository _worksiteRepository;
        private readonly IMapper _mapper;

        public GetWorksiteByIdQueryHandler(IWorksiteRepository worksiteRepository, IMapper mapper)
        {
            _worksiteRepository = worksiteRepository;
            _mapper = mapper;
        }

        public async Task<WorksiteDto> Handle(GetWorksiteByIdQuery request, CancellationToken cancellationToken)
        {
            var worksite = await _worksiteRepository.GetByIdAsync(request.Id);
            if (worksite == null)
            {
                throw new NotFoundException("Worksite", request.Id);
            }

            return _mapper.Map<WorksiteDto>(worksite);
        }
    }
}
