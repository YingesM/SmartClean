using MediatR;
using SmartClean.Application.Exceptions;
using SmartClean.Core.Interfaces;

namespace SmartClean.Application.Features.Worksites.Commands.DeleteWorksite
{
    public class DeleteWorksiteCommandHandler : IRequestHandler<DeleteWorksiteCommand, bool>
    {
        private readonly IWorksiteRepository _worksiteRepository;

        public DeleteWorksiteCommandHandler(IWorksiteRepository worksiteRepository)
        {
            _worksiteRepository = worksiteRepository;
        }

        public async Task<bool> Handle(DeleteWorksiteCommand request, CancellationToken cancellationToken)
        {
            var worksite = await _worksiteRepository.GetByIdAsync(request.Id);
            if (worksite == null)
            {
                throw new NotFoundException("Worksite", request.Id);
            }

            return await _worksiteRepository.DeleteAsync(request.Id);
        }
    }
}
