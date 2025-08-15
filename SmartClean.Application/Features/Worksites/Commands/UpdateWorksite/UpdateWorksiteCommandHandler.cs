using AutoMapper;
using MediatR;
using SmartClean.Application.DTOs;
using SmartClean.Application.Exceptions;
using SmartClean.Core.Entities;
using SmartClean.Core.Interfaces;

namespace SmartClean.Application.Features.Worksites.Commands.UpdateWorksite
{
    public class UpdateWorksiteCommandHandler : IRequestHandler<UpdateWorksiteCommand, WorksiteDto>
    {
        private readonly IWorksiteRepository _worksiteRepository;
        private readonly IMapper _mapper;

        public UpdateWorksiteCommandHandler(IWorksiteRepository worksiteRepository, IMapper mapper)
        {
            _worksiteRepository = worksiteRepository;
            _mapper = mapper;
        }

        public async Task<WorksiteDto> Handle(UpdateWorksiteCommand request, CancellationToken cancellationToken)
        {
            var existingWorksite = await _worksiteRepository.GetByIdAsync(request.Worksite.Id);
            if (existingWorksite == null)
            {
                throw new NotFoundException(nameof(Worksite), request.Worksite.Id);
            }

            var worksite = _mapper.Map<Worksite>(request.Worksite);
            var updatedWorksite = await _worksiteRepository.UpdateAsync(worksite);
            return _mapper.Map<WorksiteDto>(updatedWorksite);
        }
    }
}
