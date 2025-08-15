using SmartClean.Core.Entities;

namespace SmartClean.Core.Interfaces;

public interface IContractEmployeeRepository
{
    Task<List<ContractEmployee>> GetAllAsync();
    Task<ContractEmployee?> GetByIdAsync(string id);
    Task<List<ContractEmployee>> GetActiveContractEmployeesAsync();
    Task<List<ContractEmployee>> GetContractEmployeesByAgencyAsync(string agency);
    Task<List<ContractEmployee>> GetContractEmployeesByCategoryAsync(string category);
    Task<ContractEmployee> AddAsync(ContractEmployee contractEmployee);
    Task<ContractEmployee> UpdateAsync(ContractEmployee contractEmployee);
    Task<bool> DeleteAsync(string id);
    Task<bool> ExistsAsync(string id);
}
