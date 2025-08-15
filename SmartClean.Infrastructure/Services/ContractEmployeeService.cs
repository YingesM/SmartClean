using AutoMapper;
using SmartClean.Application.DTOs;
using SmartClean.Application.Services;
using SmartClean.Core.Entities;
using SmartClean.Core.Interfaces;

namespace SmartClean.Infrastructure.Services;

public class ContractEmployeeService : IContractEmployeeService
{
    private readonly IContractEmployeeRepository _contractEmployeeRepository;
    private readonly IMapper _mapper;

    public ContractEmployeeService(IContractEmployeeRepository contractEmployeeRepository, IMapper mapper)
    {
        _contractEmployeeRepository = contractEmployeeRepository;
        _mapper = mapper;
    }

    public async Task<List<ContractEmployeeDto>> GetAllContractEmployeesAsync()
    {
        var employees = await _contractEmployeeRepository.GetAllAsync();
        return _mapper.Map<List<ContractEmployeeDto>>(employees);
    }

    public async Task<ContractEmployeeDto?> GetContractEmployeeByIdAsync(string id)
    {
        var employee = await _contractEmployeeRepository.GetByIdAsync(id);
        return _mapper.Map<ContractEmployeeDto>(employee);
    }

    public async Task<List<ContractEmployeeDto>> GetActiveContractEmployeesAsync()
    {
        var employees = await _contractEmployeeRepository.GetActiveContractEmployeesAsync();
        return _mapper.Map<List<ContractEmployeeDto>>(employees);
    }

    public async Task<List<ContractEmployeeDto>> GetContractEmployeesByAgencyAsync(string agency)
    {
        var employees = await _contractEmployeeRepository.GetContractEmployeesByAgencyAsync(agency);
        return _mapper.Map<List<ContractEmployeeDto>>(employees);
    }

    public async Task<List<ContractEmployeeDto>> GetContractEmployeesByCategoryAsync(string category)
    {
        var employees = await _contractEmployeeRepository.GetContractEmployeesByCategoryAsync(category);
        return _mapper.Map<List<ContractEmployeeDto>>(employees);
    }

    public async Task<ContractEmployeeDto> CreateContractEmployeeAsync(CreateContractEmployeeDto createDto)
    {
        var employee = _mapper.Map<ContractEmployee>(createDto);
        var createdEmployee = await _contractEmployeeRepository.AddAsync(employee);
        return _mapper.Map<ContractEmployeeDto>(createdEmployee);
    }

    public async Task<ContractEmployeeDto> UpdateContractEmployeeAsync(UpdateContractEmployeeDto updateDto)
    {
        var employee = _mapper.Map<ContractEmployee>(updateDto);
        var updatedEmployee = await _contractEmployeeRepository.UpdateAsync(employee);
        return _mapper.Map<ContractEmployeeDto>(updatedEmployee);
    }

    public async Task<bool> DeleteContractEmployeeAsync(string id)
    {
        return await _contractEmployeeRepository.DeleteAsync(id);
    }

    public async Task<bool> ExistsAsync(string id)
    {
        return await _contractEmployeeRepository.ExistsAsync(id);
    }
}
