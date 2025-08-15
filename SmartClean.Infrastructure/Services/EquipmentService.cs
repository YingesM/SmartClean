using AutoMapper;
using SmartClean.Application.DTOs;
using SmartClean.Application.Services;
using SmartClean.Core.Entities;
using SmartClean.Core.Interfaces;

namespace SmartClean.Infrastructure.Services;

public class EquipmentService : IEquipmentService
{
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IMapper _mapper;

    public EquipmentService(IEquipmentRepository equipmentRepository, IMapper mapper)
    {
        _equipmentRepository = equipmentRepository;
        _mapper = mapper;
    }

    public async Task<List<EquipmentDto>> GetAllEquipmentAsync()
    {
        var equipment = await _equipmentRepository.GetAllAsync();
        return _mapper.Map<List<EquipmentDto>>(equipment);
    }

    public async Task<EquipmentDto?> GetEquipmentByIdAsync(string id)
    {
        var equipment = await _equipmentRepository.GetByIdAsync(id);
        return _mapper.Map<EquipmentDto>(equipment);
    }

    public async Task<List<EquipmentDto>> GetActiveEquipmentAsync()
    {
        var equipment = await _equipmentRepository.GetActiveEquipmentAsync();
        return _mapper.Map<List<EquipmentDto>>(equipment);
    }

    public async Task<List<EquipmentDto>> GetAvailableEquipmentAsync()
    {
        var equipment = await _equipmentRepository.GetAvailableEquipmentAsync();
        return _mapper.Map<List<EquipmentDto>>(equipment);
    }

    public async Task<List<EquipmentDto>> GetEquipmentByStatusAsync(EquipmentStatus status)
    {
        var equipment = await _equipmentRepository.GetEquipmentByStatusAsync(status);
        return _mapper.Map<List<EquipmentDto>>(equipment);
    }

    public async Task<List<EquipmentDto>> GetEquipmentByLocationAsync(string location)
    {
        var equipment = await _equipmentRepository.GetEquipmentByLocationAsync(location);
        return _mapper.Map<List<EquipmentDto>>(equipment);
    }

    public async Task<EquipmentDto> CreateEquipmentAsync(CreateEquipmentDto createDto)
    {
        var equipment = _mapper.Map<Equipment>(createDto);
        var createdEquipment = await _equipmentRepository.AddAsync(equipment);
        return _mapper.Map<EquipmentDto>(createdEquipment);
    }

    public async Task<EquipmentDto> UpdateEquipmentAsync(UpdateEquipmentDto updateDto)
    {
        var equipment = _mapper.Map<Equipment>(updateDto);
        var updatedEquipment = await _equipmentRepository.UpdateAsync(equipment);
        return _mapper.Map<EquipmentDto>(updatedEquipment);
    }

    public async Task<bool> DeleteEquipmentAsync(string id)
    {
        return await _equipmentRepository.DeleteAsync(id);
    }

    public async Task<bool> ExistsAsync(string id)
    {
        return await _equipmentRepository.ExistsAsync(id);
    }
}
