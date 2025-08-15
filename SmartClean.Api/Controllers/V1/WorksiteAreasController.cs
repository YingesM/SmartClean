using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartClean.Api.Controllers.Base;
using SmartClean.Application.DTOs;

namespace SmartClean.Api.Controllers.V1;

[ApiVersion("1.0")]
public class WorksiteAreasController : BaseApiController
{
    private readonly IMediator _mediator;

    public WorksiteAreasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<WorksiteAreaDto>>> GetAll()
    {
        // TODO: Implement GetAllWorksiteAreasQuery
        return Ok(new List<WorksiteAreaDto>());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WorksiteAreaDto>> GetById(string id)
    {
        // TODO: Implement GetWorksiteAreaByIdQuery
        return Ok(new WorksiteAreaDto());
    }

    [HttpGet("worksite/{worksiteId}")]
    public async Task<ActionResult<List<WorksiteAreaDto>>> GetByWorksite(string worksiteId)
    {
        // TODO: Implement GetWorksiteAreasByWorksiteQuery
        return Ok(new List<WorksiteAreaDto>());
    }
}
