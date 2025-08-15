using AutoMapper;
using SmartClean.Application.DTOs;
using SmartClean.Application.Services;
using SmartClean.Core.Entities;
using SmartClean.Core.Interfaces;

namespace SmartClean.Infrastructure.Services;

public class WorksiteAreaService : IWorksiteAreaService
{
    private readonly IWorksiteAreaRepository _worksiteAreaRepository;
    private readonly IMapper _mapper;

    public WorksiteAreaService(IWorksiteAreaRepository worksiteAreaRepository, IMapper mapper)
    {
        _worksiteAreaRepository = worksiteAreaRepository;
        _mapper = mapper;
    }

    public async Task<List<WorksiteAreaDto>> GetAllWorksiteAreasAsync()
    {
        var worksiteAreas = await _worksiteAreaRepository.GetAllAsync();
        return _mapper.Map<List<WorksiteAreaDto>>(worksiteAreas);
    }

    public async Task<WorksiteAreaDto?> GetWorksiteAreaByIdAsync(string id)
    {
        var worksiteArea = await _worksiteAreaRepository.GetByIdAsync(id);
        return _mapper.Map<WorksiteAreaDto>(worksiteArea);
    }

    public async Task<List<WorksiteAreaDto>> GetActiveWorksiteAreasAsync()
    {
        var worksiteAreas = await _worksiteAreaRepository.GetActiveWorksiteAreasAsync();
        return _mapper.Map<List<WorksiteAreaDto>>(worksiteAreas);
    }

    public async Task<List<WorksiteAreaDto>> GetWorksiteAreasByTypeAsync(WorksiteAreaType type)
    {
        var worksiteAreas = await _worksiteAreaRepository.GetWorksiteAreasByTypeAsync(type);
        return _mapper.Map<List<WorksiteAreaDto>>(worksiteAreas);
    }

    public async Task<List<WorksiteAreaDto>> GetWorksiteAreasByWorksiteAsync(string worksiteId)
    {
        var worksiteAreas = await _worksiteAreaRepository.GetWorksiteAreasByWorksiteAsync(worksiteId);
        return _mapper.Map<List<WorksiteAreaDto>>(worksiteAreas);
    }

    public async Task<WorksiteAreaDto> CreateWorksiteAreaAsync(CreateWorksiteAreaDto createDto)
    {
        var worksiteArea = _mapper.Map<WorksiteArea>(createDto);
        var createdWorksiteArea = await _worksiteAreaRepository.AddAsync(worksiteArea);
        return _mapper.Map<WorksiteAreaDto>(createdWorksiteArea);
    }

    public async Task<WorksiteAreaDto> UpdateWorksiteAreaAsync(UpdateWorksiteAreaDto updateDto)
    {
        var worksiteArea = _mapper.Map<WorksiteArea>(updateDto);
        var updatedWorksiteArea = await _worksiteAreaRepository.UpdateAsync(worksiteArea);
        return _mapper.Map<WorksiteAreaDto>(updatedWorksiteArea);
    }

    public async Task<bool> DeleteWorksiteAreaAsync(string id)
    {
        return await _worksiteAreaRepository.DeleteAsync(id);
    }

    public async Task<bool> ExistsAsync(string id)
    {
        return await _worksiteAreaRepository.ExistsAsync(id);
    }
}
