using Microsoft.EntityFrameworkCore;
using SmartClean.Core.Entities;

namespace SmartClean.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Worksite> Worksites => Set<Worksite>();
        public DbSet<WorksiteArea> WorksiteAreas => Set<WorksiteArea>();
        public DbSet<ContractEmployee> ContractEmployees => Set<ContractEmployee>();
        public DbSet<Equipment> Equipments => Set<Equipment>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Worksite>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.Id).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Address).HasMaxLength(200).IsRequired();
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.PostalCode).HasMaxLength(20);
                entity.Property(e => e.ContactPerson).HasMaxLength(50);
                entity.Property(e => e.ContactPhone).HasMaxLength(20);
                entity.Property(e => e.ContactEmail).HasMaxLength(100);
                entity.Property(e => e.SpecialRequirements).HasMaxLength(500);
                
                entity.HasOne(e => e.Parent)
                    .WithMany(e => e.Children)
                    .HasForeignKey(e => e.ParentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.WorksiteAreas)
                    .WithOne(e => e.Worksite)
                    .HasForeignKey(e => e.WorksiteId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<WorksiteArea>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.Id).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.CleaningInstructions).HasMaxLength(1000);
                entity.Property(e => e.RequiredEquipment).HasMaxLength(500);
                entity.Property(e => e.RequiredSupplies).HasMaxLength(500);
                entity.Property(e => e.WorksiteId).HasMaxLength(10).IsRequired();
            });

            builder.Entity<ContractEmployee>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.Id).HasMaxLength(10).IsRequired();
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Address).HasMaxLength(200);
                entity.Property(e => e.Position).HasMaxLength(50);
            });

            builder.Entity<Equipment>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.Id).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Model).HasMaxLength(50);
                entity.Property(e => e.SerialNumber).HasMaxLength(50);
                entity.Property(e => e.Status).HasMaxLength(50);
                entity.Property(e => e.Location).HasMaxLength(200);
            });
        }
    }
}
