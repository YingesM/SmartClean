using AutoMapper;
using SmartClean.Application.DTOs;
using SmartClean.Application.Services;
using SmartClean.Core.Interfaces;

namespace SmartClean.Infrastructure.Services;

public class WorksiteService : IWorksiteService
{
    private readonly IWorksiteRepository _worksiteRepository;
    private readonly IMapper _mapper;

    public WorksiteService(IWorksiteRepository worksiteRepository, IMapper mapper)
    {
        _worksiteRepository = worksiteRepository;
        _mapper = mapper;
    }

    public async Task<List<WorksiteDto>> GetAllWorksitesAsync()
    {
        var worksites = await _worksiteRepository.GetAllAsync();
        return _mapper.Map<List<WorksiteDto>>(worksites);
    }

    public async Task<WorksiteDto?> GetWorksiteByIdAsync(string id)
    {
        var worksite = await _worksiteRepository.GetByIdAsync(id);
        return _mapper.Map<WorksiteDto>(worksite);
    }

    public async Task<List<WorksiteDto>> GetActiveWorksitesAsync()
    {
        var worksites = await _worksiteRepository.GetActiveWorksitesAsync();
        return _mapper.Map<List<WorksiteDto>>(worksites);
    }

    public async Task<List<WorksiteDto>> GetWorksitesByTypeAsync(WorksiteType type)
    {
        var worksites = await _worksiteRepository.GetWorksitesByTypeAsync(type);
        return _mapper.Map<List<WorksiteDto>>(worksites);
    }

    public async Task<List<WorksiteDto>> GetRootWorksitesAsync()
    {
        var worksites = await _worksiteRepository.GetRootWorksitesAsync();
        return _mapper.Map<List<WorksiteDto>>(worksites);
    }

    public async Task<List<WorksiteDto>> GetChildrenAsync(string parentId)
    {
        var worksites = await _worksiteRepository.GetChildrenAsync(parentId);
        return _mapper.Map<List<WorksiteDto>>(worksites);
    }

    public async Task<List<WorksiteDto>> GetAncestorsAsync(string worksiteId)
    {
        var worksites = await _worksiteRepository.GetAncestorsAsync(worksiteId);
        return _mapper.Map<List<WorksiteDto>>(worksites);
    }

    public async Task<List<WorksiteDto>> GetDescendantsAsync(string worksiteId)
    {
        var worksites = await _worksiteRepository.GetDescendantsAsync(worksiteId);
        return _mapper.Map<List<WorksiteDto>>(worksites);
    }

    public async Task<WorksiteDto> CreateWorksiteAsync(CreateWorksiteDto createDto)
    {
        var worksite = _mapper.Map<Worksite>(createDto);
        var createdWorksite = await _worksiteRepository.AddAsync(worksite);
        return _mapper.Map<WorksiteDto>(createdWorksite);
    }

    public async Task<WorksiteDto> UpdateWorksiteAsync(UpdateWorksiteDto updateDto)
    {
        var worksite = _mapper.Map<Worksite>(updateDto);
        var updatedWorksite = await _worksiteRepository.UpdateAsync(worksite);
        return _mapper.Map<WorksiteDto>(updatedWorksite);
    }

    public async Task<bool> DeleteWorksiteAsync(string id)
    {
        return await _worksiteRepository.DeleteAsync(id);
    }

    public async Task<bool> ExistsAsync(string id)
    {
        return await _worksiteRepository.ExistsAsync(id);
    }
}
