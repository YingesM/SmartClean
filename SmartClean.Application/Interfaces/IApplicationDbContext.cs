using Microsoft.EntityFrameworkCore;
using SmartClean.Core.Entities;

namespace SmartClean.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Worksite> Worksites { get; }
        DbSet<ContractEmployee> ContractEmployees { get; }
        DbSet<Equipment> Equipments { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
