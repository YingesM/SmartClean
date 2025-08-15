using Microsoft.EntityFrameworkCore;
using SmartClean.Core.Entities;
using SmartClean.Core.Interfaces;

namespace SmartClean.Infrastructure.Data
{
    public class WorksiteRepository : IWorksiteRepository
    {
        private readonly ApplicationDbContext _context;

        public WorksiteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Worksite>> GetAllAsync()
        {
            return await _context.Worksites
                .Include(w => w.Parent)
                .Include(w => w.Children)
                .Include(w => w.WorksiteAreas)
                .Where(w => w.DateDeleted == null)
                .OrderBy(w => w.Name)
                .ToListAsync();
        }

        public async Task<Worksite?> GetByIdAsync(string id)
        {
            return await _context.Worksites
                .Include(w => w.Parent)
                .Include(w => w.Children)
                .Include(w => w.WorksiteAreas)
                .FirstOrDefaultAsync(w => w.Id == id && w.DateDeleted == null);
        }

        public async Task<Worksite> AddAsync(Worksite worksite)
        {
            worksite.DateCreated = DateTime.UtcNow;
            _context.Worksites.Add(worksite);
            await _context.SaveChangesAsync();
            return worksite;
        }

        public async Task<Worksite> UpdateAsync(Worksite worksite)
        {
            worksite.DateUpdated = DateTime.UtcNow;
            _context.Worksites.Update(worksite);
            await _context.SaveChangesAsync();
            return worksite;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var worksite = await _context.Worksites.FindAsync(id);
            if (worksite == null)
                return false;

            worksite.DateDeleted = DateTime.UtcNow;
            worksite.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _context.Worksites
                .AnyAsync(w => w.Id == id && w.DateDeleted == null);
        }

        public async Task<IEnumerable<Worksite>> GetActiveWorksitesAsync()
        {
            return await _context.Worksites
                .Include(w => w.Parent)
                .Include(w => w.Children)
                .Where(w => w.IsActive && w.DateDeleted == null)
                .OrderBy(w => w.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Worksite>> GetWorksitesByTypeAsync(WorksiteType type)
        {
            return await _context.Worksites
                .Include(w => w.Parent)
                .Include(w => w.Children)
                .Where(w => w.Type == type && w.DateDeleted == null)
                .OrderBy(w => w.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Worksite>> GetRootWorksitesAsync()
        {
            return await _context.Worksites
                .Include(w => w.Children)
                .Where(w => w.ParentId == null && w.DateDeleted == null)
                .OrderBy(w => w.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Worksite>> GetChildrenAsync(string parentId)
        {
            return await _context.Worksites
                .Include(w => w.Children)
                .Where(w => w.ParentId == parentId && w.DateDeleted == null)
                .OrderBy(w => w.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Worksite>> GetAncestorsAsync(string worksiteId)
        {
            var ancestors = new List<Worksite>();
            var current = await _context.Worksites
                .Include(w => w.Parent)
                .FirstOrDefaultAsync(w => w.Id == worksiteId && w.DateDeleted == null);

            while (current?.Parent != null)
            {
                ancestors.Add(current.Parent);
                current = await _context.Worksites
                    .Include(w => w.Parent)
                    .FirstOrDefaultAsync(w => w.Id == current.Parent.Id && w.DateDeleted == null);
            }

            return ancestors;
        }

        public async Task<IEnumerable<Worksite>> GetDescendantsAsync(string worksiteId)
        {
            var descendants = new List<Worksite>();
            await GetDescendantsRecursiveAsync(worksiteId, descendants);
            return descendants;
        }

        private async Task GetDescendantsRecursiveAsync(string parentId, List<Worksite> descendants)
        {
            var children = await _context.Worksites
                .Where(w => w.ParentId == parentId && w.DateDeleted == null)
                .ToListAsync();

            foreach (var child in children)
            {
                descendants.Add(child);
                await GetDescendantsRecursiveAsync(child.Id, descendants);
            }
        }
    }
}
