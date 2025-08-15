using MediatR;

namespace SmartClean.Application.Features.Worksites.Commands.DeleteWorksite
{
    public class DeleteWorksiteCommand : IRequest<bool>
    {
        public string Id { get; set; } = string.Empty;
    }
}
