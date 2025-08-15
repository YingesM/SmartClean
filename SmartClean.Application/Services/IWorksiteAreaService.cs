using SmartClean.Application.DTOs;

namespace SmartClean.Application.Services;

public interface IWorksiteAreaService
{
    Task<List<WorksiteAreaDto>> GetAllWorksiteAreasAsync();
    Task<WorksiteAreaDto?> GetWorksiteAreaByIdAsync(string id);
    Task<List<WorksiteAreaDto>> GetActiveWorksiteAreasAsync();
    Task<List<WorksiteAreaDto>> GetWorksiteAreasByTypeAsync(WorksiteAreaType type);
    Task<List<WorksiteAreaDto>> GetWorksiteAreasByWorksiteAsync(string worksiteId);
    Task<WorksiteAreaDto> CreateWorksiteAreaAsync(CreateWorksiteAreaDto createDto);
    Task<WorksiteAreaDto> UpdateWorksiteAreaAsync(UpdateWorksiteAreaDto updateDto);
    Task<bool> DeleteWorksiteAreaAsync(string id);
    Task<bool> ExistsAsync(string id);
}
