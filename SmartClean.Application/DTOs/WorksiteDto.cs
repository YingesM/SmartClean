using SmartClean.Core.Entities;

namespace SmartClean.Application.DTOs
{
    public class WorksiteDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public int SquareFootage { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfKitchens { get; set; }
        public int ToiletCount { get; set; }
        public int HandwashCount { get; set; }
        public string SpecialRequirements { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public WorksiteType Type { get; set; }
        public CleaningFrequency Frequency { get; set; }
        public string? ParentId { get; set; }
        public WorksiteDto? Parent { get; set; }
        public List<WorksiteDto> Children { get; set; } = new();
        public List<WorksiteAreaDto> WorksiteAreas { get; set; } = new();
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }

    public class CreateWorksiteDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public int SquareFootage { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfKitchens { get; set; }
        public int ToiletCount { get; set; }
        public int HandwashCount { get; set; }
        public string SpecialRequirements { get; set; } = string.Empty;
        public WorksiteType Type { get; set; }
        public CleaningFrequency Frequency { get; set; }
        public string? ParentId { get; set; }
    }

    public class UpdateWorksiteDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public int SquareFootage { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfKitchens { get; set; }
        public int ToiletCount { get; set; }
        public int HandwashCount { get; set; }
        public string SpecialRequirements { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public WorksiteType Type { get; set; }
        public CleaningFrequency Frequency { get; set; }
        public string? ParentId { get; set; }
    }
}
