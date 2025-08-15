using AutoMapper;
using SmartClean.Application.DTOs;
using SmartClean.Core.Entities;

namespace SmartClean.Application.Mappings
{
    public class WorksiteAreaMappingProfile : Profile
    {
        public WorksiteAreaMappingProfile()
        {
            CreateMap<WorksiteArea, WorksiteAreaDto>()
                .ForMember(dest => dest.Worksite, opt => opt.MapFrom(src => src.Worksite));
            
            CreateMap<CreateWorksiteAreaDto, WorksiteArea>()
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
                .ForMember(dest => dest.DateUpdated, opt => opt.Ignore())
                .ForMember(dest => dest.DateDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Worksite, opt => opt.Ignore());
            
            CreateMap<UpdateWorksiteAreaDto, WorksiteArea>()
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
                .ForMember(dest => dest.DateDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.DateUpdated, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Worksite, opt => opt.Ignore());
        }
    }
}
