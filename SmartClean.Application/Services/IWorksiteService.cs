using SmartClean.Application.DTOs;
using SmartClean.Core.Entities;

namespace SmartClean.Application.Services;

public interface IWorksiteService
{
    Task<List<WorksiteDto>> GetAllWorksitesAsync();
    Task<WorksiteDto?> GetWorksiteByIdAsync(string id);
    Task<List<WorksiteDto>> GetActiveWorksitesAsync();
    Task<List<WorksiteDto>> GetWorksitesByTypeAsync(WorksiteType type);
    Task<List<WorksiteDto>> GetRootWorksitesAsync();
    Task<List<WorksiteDto>> GetChildrenAsync(string parentId);
    Task<List<WorksiteDto>> GetAncestorsAsync(string worksiteId);
    Task<List<WorksiteDto>> GetDescendantsAsync(string worksiteId);
    Task<WorksiteDto> CreateWorksiteAsync(CreateWorksiteDto createDto);
    Task<WorksiteDto> UpdateWorksiteAsync(UpdateWorksiteDto updateDto);
    Task<bool> DeleteWorksiteAsync(string id);
    Task<bool> ExistsAsync(string id);
}
