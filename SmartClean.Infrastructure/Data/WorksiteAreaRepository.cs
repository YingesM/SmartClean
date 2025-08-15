using Microsoft.EntityFrameworkCore;
using SmartClean.Core.Entities;
using SmartClean.Core.Interfaces;

namespace SmartClean.Infrastructure.Data
{
    public class WorksiteAreaRepository : IWorksiteAreaRepository
    {
        private readonly ApplicationDbContext _context;

        public WorksiteAreaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorksiteArea>> GetAllAsync()
        {
            return await _context.WorksiteAreas
                .Include(w => w.Worksite)
                .Where(w => w.DateDeleted == null)
                .OrderBy(w => w.Priority)
                .ThenBy(w => w.Name)
                .ToListAsync();
        }

        public async Task<WorksiteArea?> GetByIdAsync(string id)
        {
            return await _context.WorksiteAreas
                .Include(w => w.Worksite)
                .FirstOrDefaultAsync(w => w.Id == id && w.DateDeleted == null);
        }

        public async Task<WorksiteArea> AddAsync(WorksiteArea worksiteArea)
        {
            worksiteArea.DateCreated = DateTime.UtcNow;
            _context.WorksiteAreas.Add(worksiteArea);
            await _context.SaveChangesAsync();
            return worksiteArea;
        }

        public async Task<WorksiteArea> UpdateAsync(WorksiteArea worksiteArea)
        {
            worksiteArea.DateUpdated = DateTime.UtcNow;
            _context.WorksiteAreas.Update(worksiteArea);
            await _context.SaveChangesAsync();
            return worksiteArea;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var worksiteArea = await _context.WorksiteAreas.FindAsync(id);
            if (worksiteArea == null)
                return false;

            worksiteArea.DateDeleted = DateTime.UtcNow;
            worksiteArea.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _context.WorksiteAreas
                .AnyAsync(w => w.Id == id && w.DateDeleted == null);
        }

        public async Task<IEnumerable<WorksiteArea>> GetActiveWorksiteAreasAsync()
        {
            return await _context.WorksiteAreas
                .Include(w => w.Worksite)
                .Where(w => w.IsActive && w.DateDeleted == null)
                .OrderBy(w => w.Priority)
                .ThenBy(w => w.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<WorksiteArea>> GetWorksiteAreasByTypeAsync(WorksiteAreaType type)
        {
            return await _context.WorksiteAreas
                .Include(w => w.Worksite)
                .Where(w => w.Type == type && w.DateDeleted == null)
                .OrderBy(w => w.Priority)
                .ThenBy(w => w.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<WorksiteArea>> GetWorksiteAreasByWorksiteAsync(string worksiteId)
        {
            return await _context.WorksiteAreas
                .Include(w => w.Worksite)
                .Where(w => w.WorksiteId == worksiteId && w.DateDeleted == null)
                .OrderBy(w => w.Priority)
                .ThenBy(w => w.Name)
                .ToListAsync();
        }
    }
}
