using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using SmartClean.Api.Configuration;
using SmartClean.Application.Services;
using SmartClean.Infrastructure.Services;

namespace SmartClean.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
        
        services.AddMediatR(typeof(SmartClean.Application.AssemblyReference).Assembly);
        services.AddAutoMapper(typeof(SmartClean.Application.AssemblyReference).Assembly);
        services.AddValidatorsFromAssembly(typeof(SmartClean.Application.AssemblyReference).Assembly);
        
        services.AddScoped<IWorksiteService, WorksiteService>();
        services.AddScoped<IWorksiteAreaService, WorksiteAreaService>();
        services.AddScoped<IContractEmployeeService, ContractEmployeeService>();
        services.AddScoped<IEquipmentService, EquipmentService>();
        
        return services;
    }

    public static IServiceCollection AddApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-API-Version"),
                new MediaTypeApiVersionReader("X-API-Version"));
        });

        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }

    public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowedOrigins", policy =>
            {
                policy.WithOrigins(configuration.GetSection("AllowedOrigins").Get<string[]>() ?? new string[0])
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials();
            });
        });

        return services;
    }

    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "SmartClean API",
                Version = "v1",
                Description = "Clean Architecture implementation for SmartClean with Worksite and WorksiteArea entities",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "YingesM",
                    Email = "yinges.mesele1@gmail.com"
                }
            });

            c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme",
                Name = "Authorization",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
                {
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Reference = new Microsoft.OpenApi.Models.OpenApiReference
                        {
                            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }
}
