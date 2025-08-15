# SmartClean - Enhanced Folder Structure

## 📁 **Project Overview**

This document outlines the comprehensive folder structure for the SmartClean Clean Architecture implementation, designed for scalability, maintainability, and best practices.

## 🏗️ **Solution Structure**

```
SmartClean/
├── SmartClean.Api/                    # Presentation Layer
├── SmartClean.Application/            # Application Layer
├── SmartClean.Core/                   # Domain Layer
├── SmartClean.Infrastructure/         # Infrastructure Layer
├── SmartClean.Shared/                 # Shared Components
├── README.md                          # Project Documentation
├── FOLDER_STRUCTURE.md               # This File
└── SmartClean.sln                     # Solution File
```

## 📂 **SmartClean.Api (Presentation Layer)**

```
SmartClean.Api/
├── Controllers/
│   ├── Base/
│   │   └── BaseApiController.cs       # Base controller with common functionality
│   └── V1/                            # API Version 1.0 Controllers
│       ├── WorksitesController.cs     # Worksite CRUD operations
│       ├── WorksiteAreasController.cs # WorksiteArea operations
│       ├── ContractEmployeesController.cs # Employee management
│       └── EquipmentController.cs     # Equipment management
├── Configuration/
│   └── AppSettings.cs                 # Application configuration classes
├── Extensions/
│   └── ServiceCollectionExtensions.cs # DI and service configuration
├── Middleware/
│   ├── ExceptionHandlingMiddleware.cs # Global exception handling
│   └── ExceptionHandlerMiddleware.cs  # Legacy exception handler
├── Properties/
│   └── launchSettings.json           # Launch configuration
├── Program.cs                         # Application entry point
├── ServiceExtensions.cs              # Legacy service extensions
├── appsettings.json                  # Application settings
├── appsettings.Development.json      # Development settings
└── SmartClean.Api.csproj            # Project file
```

### **Controller Structure Benefits:**
- **Versioning**: API versioning support with V1, V2, etc.
- **Base Controller**: Common functionality and error handling
- **Separation**: Each entity has its own controller
- **Consistency**: Standardized CRUD operations

## 📂 **SmartClean.Application (Application Layer)**

```
SmartClean.Application/
├── DTOs/                              # Data Transfer Objects
│   ├── WorksiteDto.cs                 # Worksite DTOs
│   ├── WorksiteAreaDto.cs             # WorksiteArea DTOs
│   ├── ContractEmployeeDto.cs         # Employee DTOs
│   ├── EquipmentDto.cs                # Equipment DTOs
│   └── EmailRequest.cs                # Email DTOs
├── Exceptions/                        # Custom Exceptions
│   ├── NotFoundException.cs           # Resource not found
│   └── ValidationException.cs         # Validation errors
├── Features/                          # CQRS Features
│   └── Worksites/                     # Worksite features
│       ├── Commands/                  # Write operations
│       │   ├── CreateWorksite/
│       │   ├── UpdateWorksite/
│       │   └── DeleteWorksite/
│       └── Queries/                   # Read operations
│           ├── GetAllWorksites/
│           └── GetWorksiteById/
├── Interfaces/                        # Application Interfaces
│   └── IApplicationDbContext.cs       # DbContext interface
├── Mappings/                          # AutoMapper Profiles
│   ├── WorksiteMappingProfile.cs      # Worksite mappings
│   └── WorksiteAreaMappingProfile.cs  # WorksiteArea mappings
├── Services/                          # Business Logic Services
│   ├── IWorksiteService.cs            # Worksite business logic
│   ├── IWorksiteAreaService.cs        # WorksiteArea business logic
│   ├── IContractEmployeeService.cs    # Employee business logic
│   └── IEquipmentService.cs           # Equipment business logic
├── Validators/                        # FluentValidation
│   ├── CreateWorksiteDtoValidator.cs  # Worksite validation
│   ├── UpdateWorksiteDtoValidator.cs  # Worksite validation
│   ├── CreateWorksiteAreaDtoValidator.cs
│   └── UpdateWorksiteAreaDtoValidator.cs
├── Behaviours/                        # MediatR Behaviors
├── AssemblyReference.cs               # Assembly reference
└── SmartClean.Application.csproj      # Project file
```

### **Application Layer Benefits:**
- **CQRS**: Command Query Responsibility Segregation
- **Services**: Business logic encapsulation
- **Validation**: Comprehensive input validation
- **Mapping**: Clean object transformations

## 📂 **SmartClean.Core (Domain Layer)**

```
SmartClean.Core/
├── Entities/                          # Domain Entities
│   ├── BaseEntity.cs                  # Base entity class
│   ├── Worksite.cs                    # Worksite domain entity
│   ├── WorksiteArea.cs                # WorksiteArea domain entity
│   ├── ContractEmployee.cs            # Employee domain entity
│   └── Equipment.cs                   # Equipment domain entity
├── Interfaces/                        # Domain Interfaces
│   ├── IWorksiteRepository.cs         # Worksite repository
│   ├── IWorksiteAreaRepository.cs     # WorksiteArea repository
│   ├── IContractEmployeeRepository.cs # Employee repository
│   ├── IEquipmentRepository.cs        # Equipment repository
│   └── IEmailService.cs               # Email service
├── Enums/                             # Domain Enums
│   ├── WorksiteType.cs                # Worksite types
│   ├── WorksiteAreaType.cs            # WorksiteArea types
│   └── EquipmentStatus.cs             # Equipment status
├── ValueObjects/                      # Value Objects
├── Events/                            # Domain Events
├── Specifications/                    # Query Specifications
└── SmartClean.Core.csproj            # Project file
```

### **Domain Layer Benefits:**
- **Entities**: Rich domain models with business logic
- **Interfaces**: Repository pattern for data access
- **Value Objects**: Immutable domain concepts
- **Events**: Domain event handling

## 📂 **SmartClean.Infrastructure (Infrastructure Layer)**

```
SmartClean.Infrastructure/
├── Data/                              # Data Access
│   ├── ApplicationDbContext.cs        # Entity Framework context
│   ├── Migrations/                    # Database migrations
│   ├── WorksiteRepository.cs          # Worksite repository implementation
│   ├── WorksiteAreaRepository.cs      # WorksiteArea repository implementation
│   ├── ContractEmployeeRepository.cs  # Employee repository implementation
│   └── EquipmentRepository.cs         # Equipment repository implementation
├── Services/                          # Infrastructure Services
│   ├── WorksiteService.cs             # Worksite service implementation
│   ├── WorksiteAreaService.cs         # WorksiteArea service implementation
│   ├── ContractEmployeeService.cs     # Employee service implementation
│   ├── EquipmentService.cs            # Equipment service implementation
│   └── SmtpEmailService.cs            # Email service implementation
├── Identity/                          # Authentication & Authorization
├── Configuration/                     # Infrastructure Configuration
├── EmailSettings.cs                   # Email configuration
└── SmartClean.Infrastructure.csproj   # Project file
```

### **Infrastructure Layer Benefits:**
- **Repository Pattern**: Clean data access abstraction
- **Service Implementation**: Business logic implementation
- **External Services**: Email, logging, etc.
- **Configuration**: Infrastructure-specific settings

## 📂 **SmartClean.Shared (Shared Components)**

```
SmartClean.Shared/
├── Constants/                         # Shared constants
├── Extensions/                        # Extension methods
├── Helpers/                           # Utility helpers
├── Models/                            # Shared models
└── SmartClean.Shared.csproj          # Project file
```

## 🔧 **Key Architectural Patterns**

### **1. Clean Architecture**
- **Dependency Inversion**: Core depends on abstractions
- **Separation of Concerns**: Clear layer boundaries
- **Testability**: Easy to unit test each layer

### **2. CQRS (Command Query Responsibility Segregation)**
- **Commands**: Write operations (Create, Update, Delete)
- **Queries**: Read operations (Get, List, Search)
- **MediatR**: Mediator pattern implementation

### **3. Repository Pattern**
- **Abstraction**: Data access through interfaces
- **Testability**: Easy to mock repositories
- **Flexibility**: Can switch data sources

### **4. Service Layer**
- **Business Logic**: Encapsulated in services
- **Reusability**: Services can be used by multiple controllers
- **Validation**: Business rule enforcement

## 🚀 **Benefits of This Structure**

### **Scalability**
- Easy to add new entities and features
- Versioned API endpoints
- Modular architecture

### **Maintainability**
- Clear separation of concerns
- Consistent patterns across the application
- Easy to locate and modify code

### **Testability**
- Each layer can be tested independently
- Mockable interfaces
- Clear dependencies

### **Performance**
- Optimized data access patterns
- Efficient querying with Entity Framework
- Caching opportunities

### **Security**
- Centralized exception handling
- Input validation at multiple layers
- Secure configuration management

## 📋 **Next Steps**

1. **Implement Missing Services**: Complete service implementations
2. **Add Validation**: Implement comprehensive validation rules
3. **Add Authentication**: Implement JWT authentication
4. **Add Logging**: Implement structured logging
5. **Add Caching**: Implement caching strategies
6. **Add Tests**: Create unit and integration tests
7. **Add Documentation**: API documentation with Swagger
8. **Add Monitoring**: Health checks and metrics

## 🎯 **Best Practices Followed**

- ✅ **SOLID Principles**: Single responsibility, open/closed, etc.
- ✅ **DRY Principle**: Don't repeat yourself
- ✅ **KISS Principle**: Keep it simple, stupid
- ✅ **Separation of Concerns**: Clear layer boundaries
- ✅ **Dependency Injection**: Loose coupling
- ✅ **Interface Segregation**: Small, focused interfaces
- ✅ **Error Handling**: Centralized exception management
- ✅ **Configuration**: Externalized configuration
- ✅ **Logging**: Structured logging throughout
- ✅ **Validation**: Input validation at multiple layers

This structure provides a solid foundation for building scalable, maintainable, and testable applications following Clean Architecture principles.
