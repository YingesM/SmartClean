using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClean.Core.Entities
{
    public class WorksiteArea : BaseEntity
    {
        [Key]
        [MaxLength(10)]
        public string Id { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        
        public WorksiteAreaType Type { get; set; } = WorksiteAreaType.General;
        
        public int Priority { get; set; } = 1;
        
        public bool IsActive { get; set; } = true;
        
        public int EstimatedCleaningTimeMinutes { get; set; }
        
        public int RequiredStaffCount { get; set; } = 1;
        
        [MaxLength(1000)]
        public string CleaningInstructions { get; set; } = string.Empty;
        
        [MaxLength(500)]
        public string RequiredEquipment { get; set; } = string.Empty;
        
        [MaxLength(500)]
        public string RequiredSupplies { get; set; } = string.Empty;
        
        [MaxLength(10)]
        public string WorksiteId { get; set; } = string.Empty;
        
        [ForeignKey(nameof(WorksiteId))]
        public Worksite Worksite { get; set; } = null!;
    }
    
    public enum WorksiteAreaType
    {
        General,
        Restroom,
        Kitchen,
        Office,
        Corridor,
        Lobby,
        Conference,
        Storage,
        Equipment,
        Exterior,
        Parking,
        Loading,
        Security,
        Medical,
        Laboratory,
        Classroom,
        Cafeteria,
        Gym,
        Pool,
        Other
    }
}
