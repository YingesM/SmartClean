
namespace SmartClean.Core.Entities
{
    public abstract class BaseEntity
    {
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
