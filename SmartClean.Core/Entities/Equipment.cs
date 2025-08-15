using System.ComponentModel.DataAnnotations;

namespace SmartClean.Core.Entities
{
    public class Equipment : BaseEntity
    {
        [Key]
        [MaxLength(10)]
        public string Id { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        
        [MaxLength(50)]
        public string Model { get; set; } = string.Empty;
        
        [MaxLength(50)]
        public string SerialNumber { get; set; } = string.Empty;
        
        public DateTime PurchaseDate { get; set; }
        
        public decimal PurchaseCost { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        [MaxLength(50)]
        public string Status { get; set; } = string.Empty;
        
        [MaxLength(200)]
        public string Location { get; set; } = string.Empty;
        
        public DateTime? LastMaintenanceDate { get; set; }
        
        public DateTime? NextMaintenanceDate { get; set; }
    }
}
