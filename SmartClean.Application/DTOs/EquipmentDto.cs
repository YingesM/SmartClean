using SmartClean.Core.Entities;

namespace SmartClean.Application.DTOs;

public class EquipmentDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public DateTime? PurchaseDate { get; set; }
    public decimal PurchaseCost { get; set; }
    public bool IsActive { get; set; }
    public EquipmentStatus Status { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTime? LastMaintenanceDate { get; set; }
    public DateTime? NextMaintenanceDate { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    public DateTime? DateDeleted { get; set; }
}

public class CreateEquipmentDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public DateTime? PurchaseDate { get; set; }
    public decimal PurchaseCost { get; set; }
    public bool IsActive { get; set; } = true;
    public EquipmentStatus Status { get; set; } = EquipmentStatus.Available;
    public string Location { get; set; } = string.Empty;
    public DateTime? LastMaintenanceDate { get; set; }
    public DateTime? NextMaintenanceDate { get; set; }
}

public class UpdateEquipmentDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public DateTime? PurchaseDate { get; set; }
    public decimal PurchaseCost { get; set; }
    public bool IsActive { get; set; }
    public EquipmentStatus Status { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTime? LastMaintenanceDate { get; set; }
    public DateTime? NextMaintenanceDate { get; set; }
}
