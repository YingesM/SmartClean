namespace SmartClean.Application.DTOs;

public class ContractEmployeeDto
{
    public string Id { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Agency { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public DateTime? HireDate { get; set; }
    public bool IsActive { get; set; }
    public string Position { get; set; } = string.Empty;
    public decimal HourlyRate { get; set; }
    public bool IsPresent { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    public DateTime? DateDeleted { get; set; }
}

public class CreateContractEmployeeDto
{
    public string Id { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Agency { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public DateTime? HireDate { get; set; }
    public bool IsActive { get; set; } = true;
    public string Position { get; set; } = string.Empty;
    public decimal HourlyRate { get; set; }
    public bool IsPresent { get; set; } = false;
}

public class UpdateContractEmployeeDto
{
    public string Id { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Agency { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public DateTime? HireDate { get; set; }
    public bool IsActive { get; set; }
    public string Position { get; set; } = string.Empty;
    public decimal HourlyRate { get; set; }
    public bool IsPresent { get; set; }
}
