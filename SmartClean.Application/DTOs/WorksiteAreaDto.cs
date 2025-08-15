using SmartClean.Core.Entities;

namespace SmartClean.Application.DTOs
{
    public class WorksiteAreaDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public WorksiteAreaType Type { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
        public int EstimatedCleaningTimeMinutes { get; set; }
        public int RequiredStaffCount { get; set; }
        public string CleaningInstructions { get; set; } = string.Empty;
        public string RequiredEquipment { get; set; } = string.Empty;
        public string RequiredSupplies { get; set; } = string.Empty;
        public string WorksiteId { get; set; } = string.Empty;
        public WorksiteDto? Worksite { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }

    public class CreateWorksiteAreaDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public WorksiteAreaType Type { get; set; }
        public int Priority { get; set; }
        public int EstimatedCleaningTimeMinutes { get; set; }
        public int RequiredStaffCount { get; set; }
        public string CleaningInstructions { get; set; } = string.Empty;
        public string RequiredEquipment { get; set; } = string.Empty;
        public string RequiredSupplies { get; set; } = string.Empty;
        public string WorksiteId { get; set; } = string.Empty;
    }

    public class UpdateWorksiteAreaDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public WorksiteAreaType Type { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
        public int EstimatedCleaningTimeMinutes { get; set; }
        public int RequiredStaffCount { get; set; }
        public string CleaningInstructions { get; set; } = string.Empty;
        public string RequiredEquipment { get; set; } = string.Empty;
        public string RequiredSupplies { get; set; } = string.Empty;
        public string WorksiteId { get; set; } = string.Empty;
    }
}
