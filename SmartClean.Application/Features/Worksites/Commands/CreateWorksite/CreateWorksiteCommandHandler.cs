using AutoMapper;
using MediatR;
using SmartClean.Application.DTOs;
using SmartClean.Core.Entities;
using SmartClean.Core.Interfaces;

namespace SmartClean.Application.Features.Worksites.Commands.CreateWorksite
{
    public class CreateWorksiteCommandHandler : IRequestHandler<CreateWorksiteCommand, WorksiteDto>
    {
        private readonly IWorksiteRepository _worksiteRepository;
        private readonly IMapper _mapper;

        public CreateWorksiteCommandHandler(IWorksiteRepository worksiteRepository, IMapper mapper)
        {
            _worksiteRepository = worksiteRepository;
            _mapper = mapper;
        }

        public async Task<WorksiteDto> Handle(CreateWorksiteCommand request, CancellationToken cancellationToken)
        {
            var worksite = _mapper.Map<Worksite>(request.Worksite);
            var createdWorksite = await _worksiteRepository.AddAsync(worksite);
            return _mapper.Map<WorksiteDto>(createdWorksite);
        }
    }
}
