using System.ComponentModel.DataAnnotations;

namespace SmartClean.Core.Entities
{
    public class ContractEmployee : BaseEntity
    {
        [Key]
        [MaxLength(10)]
        public string Id { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
        
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;
        
        public DateTime DateOfBirth { get; set; }
        
        public DateTime HireDate { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        [MaxLength(50)]
        public string Position { get; set; } = string.Empty;
        
        public decimal HourlyRate { get; set; }
    }
}
