using SmartClean.Core.Entities;

namespace SmartClean.Core.Interfaces;

public interface IEquipmentRepository
{
    Task<List<Equipment>> GetAllAsync();
    Task<Equipment?> GetByIdAsync(string id);
    Task<List<Equipment>> GetActiveEquipmentAsync();
    Task<List<Equipment>> GetAvailableEquipmentAsync();
    Task<List<Equipment>> GetEquipmentByStatusAsync(EquipmentStatus status);
    Task<List<Equipment>> GetEquipmentByLocationAsync(string location);
    Task<Equipment> AddAsync(Equipment equipment);
    Task<Equipment> UpdateAsync(Equipment equipment);
    Task<bool> DeleteAsync(string id);
    Task<bool> ExistsAsync(string id);
}
