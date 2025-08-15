using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartClean.Api.Controllers.Base;
using SmartClean.Application.DTOs;

namespace SmartClean.Api.Controllers.V1;

[ApiVersion("1.0")]
public class EquipmentController : BaseApiController
{
    private readonly IMediator _mediator;

    public EquipmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<EquipmentDto>>> GetAll()
    {
        // TODO: Implement GetAllEquipmentQuery
        return Ok(new List<EquipmentDto>());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EquipmentDto>> GetById(string id)
    {
        // TODO: Implement GetEquipmentByIdQuery
        return Ok(new EquipmentDto());
    }

    [HttpGet("active")]
    public async Task<ActionResult<List<EquipmentDto>>> GetActive()
    {
        // TODO: Implement GetActiveEquipmentQuery
        return Ok(new List<EquipmentDto>());
    }

    [HttpGet("available")]
    public async Task<ActionResult<List<EquipmentDto>>> GetAvailable()
    {
        // TODO: Implement GetAvailableEquipmentQuery
        return Ok(new List<EquipmentDto>());
    }

    [HttpPost]
    public async Task<ActionResult<EquipmentDto>> Create(CreateEquipmentDto createDto)
    {
        // TODO: Implement CreateEquipmentCommand
        return Ok(new EquipmentDto());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EquipmentDto>> Update(string id, UpdateEquipmentDto updateDto)
    {
        // TODO: Implement UpdateEquipmentCommand
        return Ok(new EquipmentDto());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        // TODO: Implement DeleteEquipmentCommand
        return Ok();
    }
}
