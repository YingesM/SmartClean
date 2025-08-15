using SmartClean.Core.Entities;

namespace SmartClean.Core.Interfaces
{
    public interface IWorksiteRepository
    {
        Task<IEnumerable<Worksite>> GetAllAsync();
        Task<Worksite?> GetByIdAsync(string id);
        Task<Worksite> AddAsync(Worksite worksite);
        Task<Worksite> UpdateAsync(Worksite worksite);
        Task<bool> DeleteAsync(string id);
        Task<bool> ExistsAsync(string id);
        Task<IEnumerable<Worksite>> GetActiveWorksitesAsync();
        Task<IEnumerable<Worksite>> GetWorksitesByTypeAsync(WorksiteType type);
        Task<IEnumerable<Worksite>> GetRootWorksitesAsync();
        Task<IEnumerable<Worksite>> GetChildrenAsync(string parentId);
        Task<IEnumerable<Worksite>> GetAncestorsAsync(string worksiteId);
        Task<IEnumerable<Worksite>> GetDescendantsAsync(string worksiteId);
    }
}
