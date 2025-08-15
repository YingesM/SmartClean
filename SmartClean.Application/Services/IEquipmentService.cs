using SmartClean.Application.DTOs;
using SmartClean.Core.Entities;

namespace SmartClean.Application.Services;

public interface IEquipmentService
{
    Task<List<EquipmentDto>> GetAllEquipmentAsync();
    Task<EquipmentDto?> GetEquipmentByIdAsync(string id);
    Task<List<EquipmentDto>> GetActiveEquipmentAsync();
    Task<List<EquipmentDto>> GetAvailableEquipmentAsync();
    Task<List<EquipmentDto>> GetEquipmentByStatusAsync(EquipmentStatus status);
    Task<List<EquipmentDto>> GetEquipmentByLocationAsync(string location);
    Task<EquipmentDto> CreateEquipmentAsync(CreateEquipmentDto createDto);
    Task<EquipmentDto> UpdateEquipmentAsync(UpdateEquipmentDto updateDto);
    Task<bool> DeleteEquipmentAsync(string id);
    Task<bool> ExistsAsync(string id);
}
