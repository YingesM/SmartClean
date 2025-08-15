using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartClean.Api.Controllers.Base;
using SmartClean.Application.DTOs;

namespace SmartClean.Api.Controllers.V1;

[ApiVersion("1.0")]
public class ContractEmployeesController : BaseApiController
{
    private readonly IMediator _mediator;

    public ContractEmployeesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ContractEmployeeDto>>> GetAll()
    {
        // TODO: Implement GetAllContractEmployeesQuery
        return Ok(new List<ContractEmployeeDto>());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContractEmployeeDto>> GetById(string id)
    {
        // TODO: Implement GetContractEmployeeByIdQuery
        return Ok(new ContractEmployeeDto());
    }

    [HttpGet("active")]
    public async Task<ActionResult<List<ContractEmployeeDto>>> GetActive()
    {
        // TODO: Implement GetActiveContractEmployeesQuery
        return Ok(new List<ContractEmployeeDto>());
    }

    [HttpPost]
    public async Task<ActionResult<ContractEmployeeDto>> Create(CreateContractEmployeeDto createDto)
    {
        // TODO: Implement CreateContractEmployeeCommand
        return Ok(new ContractEmployeeDto());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ContractEmployeeDto>> Update(string id, UpdateContractEmployeeDto updateDto)
    {
        // TODO: Implement UpdateContractEmployeeCommand
        return Ok(new ContractEmployeeDto());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        // TODO: Implement DeleteContractEmployeeCommand
        return Ok();
    }
}
