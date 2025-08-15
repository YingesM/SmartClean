using AutoMapper;
using SmartClean.Application.DTOs;
using SmartClean.Core.Entities;

namespace SmartClean.Application.Mappings
{
    public class WorksiteMappingProfile : Profile
    {
        public WorksiteMappingProfile()
        {
            CreateMap<Worksite, WorksiteDto>()
                .ForMember(dest => dest.Parent, opt => opt.MapFrom(src => src.Parent))
                .ForMember(dest => dest.Children, opt => opt.MapFrom(src => src.Children))
                .ForMember(dest => dest.WorksiteAreas, opt => opt.MapFrom(src => src.WorksiteAreas));
            
            CreateMap<CreateWorksiteDto, Worksite>()
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
                .ForMember(dest => dest.DateUpdated, opt => opt.Ignore())
                .ForMember(dest => dest.DateDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Parent, opt => opt.Ignore())
                .ForMember(dest => dest.Children, opt => opt.Ignore())
                .ForMember(dest => dest.WorksiteAreas, opt => opt.Ignore());
            
            CreateMap<UpdateWorksiteDto, Worksite>()
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
                .ForMember(dest => dest.DateDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.DateUpdated, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Parent, opt => opt.Ignore())
                .ForMember(dest => dest.Children, opt => opt.Ignore())
                .ForMember(dest => dest.WorksiteAreas, opt => opt.Ignore());
        }
    }
}
