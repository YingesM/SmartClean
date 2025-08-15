using SmartClean.Core.Entities;

namespace SmartClean.Core.Interfaces
{
    public interface IWorksiteAreaRepository
    {
        Task<IEnumerable<WorksiteArea>> GetAllAsync();
        Task<WorksiteArea?> GetByIdAsync(string id);
        Task<WorksiteArea> AddAsync(WorksiteArea worksiteArea);
        Task<WorksiteArea> UpdateAsync(WorksiteArea worksiteArea);
        Task<bool> DeleteAsync(string id);
        Task<bool> ExistsAsync(string id);
        Task<IEnumerable<WorksiteArea>> GetActiveWorksiteAreasAsync();
        Task<IEnumerable<WorksiteArea>> GetWorksiteAreasByTypeAsync(WorksiteAreaType type);
        Task<IEnumerable<WorksiteArea>> GetWorksiteAreasByWorksiteAsync(string worksiteId);
    }
}
