using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartClean.Api.Controllers.Base;
using SmartClean.Application.DTOs;
using SmartClean.Application.Features.Worksites.Commands.CreateWorksite;
using SmartClean.Application.Features.Worksites.Commands.DeleteWorksite;
using SmartClean.Application.Features.Worksites.Commands.UpdateWorksite;
using SmartClean.Application.Features.Worksites.Queries.GetAllWorksites;
using SmartClean.Application.Features.Worksites.Queries.GetWorksiteById;

namespace SmartClean.Api.Controllers.V1;

[ApiVersion("1.0")]
public class WorksitesController : BaseApiController
{
    private readonly IMediator _mediator;

    public WorksitesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorksiteDto>>> GetAll()
    {
        var query = new GetAllWorksitesQuery();
        var result = await _mediator.Send(query);
        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WorksiteDto>> GetById(string id)
    {
        var query = new GetWorksiteByIdQuery { Id = id };
        var result = await _mediator.Send(query);
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<ActionResult<WorksiteDto>> Create(CreateWorksiteDto createWorksiteDto)
    {
        var command = new CreateWorksiteCommand { Worksite = createWorksiteDto };
        var result = await _mediator.Send(command);
        return HandleResult(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<WorksiteDto>> Update(string id, UpdateWorksiteDto updateWorksiteDto)
    {
        updateWorksiteDto.Id = id;
        var command = new UpdateWorksiteCommand { Worksite = updateWorksiteDto };
        var result = await _mediator.Send(command);
        return HandleResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        var command = new DeleteWorksiteCommand { Id = id };
        var result = await _mediator.Send(command);
        return HandleResult(result);
    }
}
