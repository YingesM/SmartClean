using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartClean.Core.Interfaces;
using SmartClean.Infrastructure.Data;

namespace SmartClean.Api
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IWorksiteRepository, WorksiteRepository>();
            services.AddScoped<IWorksiteAreaRepository, WorksiteAreaRepository>();

            services.AddMediatR(typeof(SmartClean.Application.AssemblyReference).Assembly);
            services.AddAutoMapper(typeof(SmartClean.Application.AssemblyReference).Assembly);
            services.AddValidatorsFromAssembly(typeof(SmartClean.Application.AssemblyReference).Assembly);

            return services;
        }
    }
}
