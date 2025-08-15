# SmartClean - Clean Architecture Implementation

A comprehensive cleaning management system built with .NET 9.0 and Clean Architecture principles. This project demonstrates best practices for building scalable, maintainable, and testable enterprise applications.

## 🏗️ Architecture Overview

SmartClean follows Clean Architecture principles with clear separation of concerns across multiple layers:

```
📁 SmartClean/
├── 📁 SmartClean.Core/           # Domain Layer (Entities, Interfaces)
├── 📁 SmartClean.Application/    # Application Layer (Use Cases, DTOs, Validation)
├── 📁 SmartClean.Infrastructure/ # Infrastructure Layer (Data Access, External Services)
├── 📁 SmartClean.Api/           # Presentation Layer (Web API)
└── 📁 SmartClean.Shared/        # Shared Components
```

### Architecture Principles

- **Dependency Inversion**: High-level modules don't depend on low-level modules
- **Separation of Concerns**: Each layer has a specific responsibility
- **CQRS Pattern**: Command Query Responsibility Segregation using MediatR
- **Repository Pattern**: Data access abstraction
- **Domain-Driven Design**: Business logic centered around domain entities

## 🚀 Features

### Core Entities

#### 1. Worksite Management
- **Parent-Child Hierarchy**: Support for complex facility structures
- **Multiple Types**: Terminal, MRO, Cargo, VIP, Office, etc.
- **Comprehensive Details**: Address, contact info, specifications
- **Cleaning Frequency**: Daily, Weekly, Bi-weekly, Monthly, etc.

#### 2. WorksiteArea Master Data
- **Area Types**: Restroom, Kitchen, Office, Corridor, Lobby, etc.
- **Priority-Based Scheduling**: Configurable cleaning priorities
- **Resource Planning**: Staff requirements, equipment, supplies
- **Detailed Instructions**: Step-by-step cleaning procedures

#### 3. Additional Entities
- **ContractEmployee**: Staff management
- **Equipment**: Asset tracking

### Key Features

- ✅ **String-Based IDs**: Human-readable identifiers (e.g., "T1", "MRO", "WA001")
- ✅ **Soft Delete**: Data preservation with logical deletion
- ✅ **Audit Trail**: Creation, update, and deletion timestamps
- ✅ **Validation**: Comprehensive input validation using FluentValidation
- ✅ **AutoMapper**: Clean object-to-object mapping
- ✅ **Swagger Documentation**: Interactive API documentation
- ✅ **Structured Logging**: Serilog integration for comprehensive logging

## 🛠️ Technology Stack

- **.NET 9.0**: Latest .NET framework
- **ASP.NET Core Web API**: RESTful API framework
- **Entity Framework Core**: ORM for data access
- **SQL Server**: Database (configurable)
- **MediatR**: CQRS implementation
- **AutoMapper**: Object mapping
- **FluentValidation**: Input validation
- **Serilog**: Structured logging
- **Swagger/OpenAPI**: API documentation

## 📋 Prerequisites

- .NET 9.0 SDK
- SQL Server (LocalDB, Express, or Full)
- Visual Studio 2022 or VS Code
- Git

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone <repository-url>
cd CleanArchitecture
```

### 2. Database Setup

Update the connection string in `SmartClean.Api/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SmartCleanDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

### 3. Run Database Migrations

```bash
cd SmartClean.Infrastructure
dotnet ef database update --startup-project ../SmartClean.Api
```

### 4. Build and Run

```bash
cd SmartClean.Api
dotnet build
dotnet run
```

The API will be available at: `https://localhost:7001` (or `http://localhost:5001`)

### 5. Access Swagger Documentation

Navigate to: `https://localhost:7001/swagger`

## 📚 API Endpoints

### Worksites

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/worksites` | Get all worksites |
| GET | `/api/worksites/{id}` | Get worksite by ID |
| POST | `/api/worksites` | Create new worksite |
| PUT | `/api/worksites/{id}` | Update worksite |
| DELETE | `/api/worksites/{id}` | Delete worksite |

### Worksite Areas

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/worksiteareas` | Get all worksite areas |
| GET | `/api/worksiteareas/{id}` | Get worksite area by ID |
| GET | `/api/worksiteareas/worksite/{worksiteId}` | Get areas for specific worksite |

## 📊 Data Models

### Worksite Entity

```csharp
public class Worksite : BaseEntity
{
    public string Id { get; set; }                    // "T1", "MRO", etc.
    public string Name { get; set; }                  // "Terminal 1"
    public string Address { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string ContactPerson { get; set; }
    public string ContactPhone { get; set; }
    public string ContactEmail { get; set; }
    public int SquareFootage { get; set; }
    public int NumberOfRooms { get; set; }
    public int NumberOfBathrooms { get; set; }
    public int NumberOfKitchens { get; set; }
    public int ToiletCount { get; set; }
    public int HandwashCount { get; set; }
    public string SpecialRequirements { get; set; }
    public bool IsActive { get; set; }
    public WorksiteType Type { get; set; }
    public CleaningFrequency Frequency { get; set; }
    
    // Parent-Child Relationship
    public string? ParentId { get; set; }
    public Worksite? Parent { get; set; }
    public ICollection<Worksite> Children { get; set; }
    
    // Navigation to Areas
    public ICollection<WorksiteArea> WorksiteAreas { get; set; }
}
```

### WorksiteArea Entity

```csharp
public class WorksiteArea : BaseEntity
{
    public string Id { get; set; }                    // "WA001", "WA002", etc.
    public string Name { get; set; }                  // "Main Restroom"
    public string Description { get; set; }
    public WorksiteAreaType Type { get; set; }        // Restroom, Kitchen, etc.
    public int Priority { get; set; }                 // 1 = Highest priority
    public bool IsActive { get; set; }
    public int EstimatedCleaningTimeMinutes { get; set; }
    public int RequiredStaffCount { get; set; }
    public string CleaningInstructions { get; set; }
    public string RequiredEquipment { get; set; }
    public string RequiredSupplies { get; set; }
    
    // Navigation to Worksite
    public string WorksiteId { get; set; }
    public Worksite Worksite { get; set; }
}
```

## 🔧 Configuration

### Connection String

Configure your database connection in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your-server;Database=SmartCleanDb;Trusted_Connection=true;"
  }
}
```

### Logging

Serilog is configured for structured logging:

```json
{
  "Serilog": {
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning"
      }
    }
  }
}
```

## 🧪 Testing

### Unit Tests

```bash
dotnet test
```

### Integration Tests

```bash
dotnet test --filter "Category=Integration"
```

## 📁 Project Structure

```
SmartClean/
├── SmartClean.Core/
│   ├── Entities/                 # Domain entities
│   │   ├── BaseEntity.cs
│   │   ├── Worksite.cs
│   │   ├── WorksiteArea.cs
│   │   ├── ContractEmployee.cs
│   │   └── Equipment.cs
│   └── Interfaces/              # Repository interfaces
│       ├── IWorksiteRepository.cs
│       └── IWorksiteAreaRepository.cs
│
├── SmartClean.Application/
│   ├── DTOs/                    # Data Transfer Objects
│   │   ├── WorksiteDto.cs
│   │   └── WorksiteAreaDto.cs
│   ├── Features/                # CQRS Commands & Queries
│   │   └── Worksites/
│   │       ├── Commands/
│   │       └── Queries/
│   ├── Validators/              # FluentValidation rules
│   │   ├── CreateWorksiteDtoValidator.cs
│   │   └── UpdateWorksiteDtoValidator.cs
│   └── Mappings/                # AutoMapper profiles
│       ├── WorksiteMappingProfile.cs
│       └── WorksiteAreaMappingProfile.cs
│
├── SmartClean.Infrastructure/
│   └── Data/                    # Data access layer
│       ├── ApplicationDbContext.cs
│       ├── WorksiteRepository.cs
│       └── WorksiteAreaRepository.cs
│
├── SmartClean.Api/
│   ├── Controllers/             # API controllers
│   │   ├── WorksitesController.cs
│   │   └── WorksiteAreasController.cs
│   ├── Middleware/              # Custom middleware
│   ├── ServiceExtensions.cs     # DI configuration
│   └── Program.cs               # Application entry point
│
└── SmartClean.Shared/           # Shared components
```

## 🔄 CQRS Implementation

The application uses the CQRS pattern with MediatR:

### Commands (Write Operations)

```csharp
public class CreateWorksiteCommand : IRequest<WorksiteDto>
{
    public CreateWorksiteDto Worksite { get; set; }
}

public class UpdateWorksiteCommand : IRequest<WorksiteDto>
{
    public string Id { get; set; }
    public UpdateWorksiteDto Worksite { get; set; }
}

public class DeleteWorksiteCommand : IRequest<bool>
{
    public string Id { get; set; }
}
```

### Queries (Read Operations)

```csharp
public class GetAllWorksitesQuery : IRequest<IEnumerable<WorksiteDto>>
{
}

public class GetWorksiteByIdQuery : IRequest<WorksiteDto?>
{
    public string Id { get; set; }
}
```

## 🎯 Business Rules

### Validation Rules

- **ID Format**: Must be uppercase letters and numbers only (max 10 characters)
- **Required Fields**: Name, Address, Contact information
- **Email Validation**: Proper email format for contact emails
- **Positive Numbers**: Square footage, room counts, cleaning times
- **Priority Range**: Worksite areas must have priority > 0

### Hierarchical Rules

- **Parent-Child**: Worksites can have parent worksites for complex facility structures
- **Cascade Delete**: Deleting a parent worksite affects child worksites
- **Circular Reference Prevention**: Self-referencing relationships are prevented

## 🚀 Deployment

### Docker Support

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SmartClean.Api/SmartClean.Api.csproj", "SmartClean.Api/"]
COPY ["SmartClean.Application/SmartClean.Application.csproj", "SmartClean.Application/"]
COPY ["SmartClean.Infrastructure/SmartClean.Infrastructure.csproj", "SmartClean.Infrastructure/"]
COPY ["SmartClean.Core/SmartClean.Core.csproj", "SmartClean.Core/"]
RUN dotnet restore "SmartClean.Api/SmartClean.Api.csproj"
COPY . .
WORKDIR "/src/SmartClean.Api"
RUN dotnet build "SmartClean.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartClean.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartClean.Api.dll"]
```

### Azure Deployment

1. Create Azure SQL Database
2. Update connection string
3. Deploy to Azure App Service
4. Configure environment variables

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🆘 Support

For support and questions:

- Create an issue in the repository
- Contact the development team
- Check the documentation

## 🔮 Roadmap

- [ ] Authentication & Authorization
- [ ] Real-time notifications
- [ ] Mobile application
- [ ] Advanced reporting
- [ ] Integration with IoT devices
- [ ] Machine learning for scheduling optimization

---

**SmartClean** - Building the future of facility management with Clean Architecture principles.
