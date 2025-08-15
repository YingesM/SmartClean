using SmartClean.Application.DTOs;

namespace SmartClean.Application.Services;

public interface IContractEmployeeService
{
    Task<List<ContractEmployeeDto>> GetAllContractEmployeesAsync();
    Task<ContractEmployeeDto?> GetContractEmployeeByIdAsync(string id);
    Task<List<ContractEmployeeDto>> GetActiveContractEmployeesAsync();
    Task<List<ContractEmployeeDto>> GetContractEmployeesByAgencyAsync(string agency);
    Task<List<ContractEmployeeDto>> GetContractEmployeesByCategoryAsync(string category);
    Task<ContractEmployeeDto> CreateContractEmployeeAsync(CreateContractEmployeeDto createDto);
    Task<ContractEmployeeDto> UpdateContractEmployeeAsync(UpdateContractEmployeeDto updateDto);
    Task<bool> DeleteContractEmployeeAsync(string id);
    Task<bool> ExistsAsync(string id);
}
