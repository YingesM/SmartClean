using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClean.Core.Entities
{
    public class Worksite : BaseEntity
    {
        [Key]
        [MaxLength(10)]
        public string Id { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;
        
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;
        
        [MaxLength(20)]
        public string PostalCode { get; set; } = string.Empty;
        
        [MaxLength(50)]
        public string ContactPerson { get; set; } = string.Empty;
        
        [MaxLength(20)]
        public string ContactPhone { get; set; } = string.Empty;
        
        [MaxLength(100)]
        [EmailAddress]
        public string ContactEmail { get; set; } = string.Empty;
        
        public int SquareFootage { get; set; }
        
        public int NumberOfRooms { get; set; }
        
        public int NumberOfBathrooms { get; set; }
        
        public int NumberOfKitchens { get; set; }
        
        public int ToiletCount { get; set; }
        
        public int HandwashCount { get; set; }
        
        [MaxLength(500)]
        public string SpecialRequirements { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
        
        public WorksiteType Type { get; set; } = WorksiteType.Terminal;
        
        public CleaningFrequency Frequency { get; set; } = CleaningFrequency.Daily;
        
        [MaxLength(10)]
        public string? ParentId { get; set; }
        
        [ForeignKey(nameof(ParentId))]
        public Worksite? Parent { get; set; }
        
        public ICollection<Worksite> Children { get; set; } = new List<Worksite>();
        
        public ICollection<WorksiteArea> WorksiteAreas { get; set; } = new List<WorksiteArea>();
    }
    
    public enum WorksiteType
    {
        Terminal,
        MRO,
        Cargo,
        VIP,
        Office,
        Retail,
        Industrial,
        Healthcare,
        Educational,
        Residential,
        Hospitality,
        Other
    }
    
    public enum CleaningFrequency
    {
        Daily,
        Weekly,
        BiWeekly,
        Monthly,
        Quarterly,
        OnDemand
    }
}
