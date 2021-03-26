using AutoMapper;
using System;
using timeSheet.Repository.Contract.Entities;
using timeSheet.Services.Contract.Models.Project;

namespace timesheet.Services.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectDto, Project>()
                .ForMember(
                d => d.Client,
                o => o.MapFrom(src => src.Customer))
                .ForMember(
                d => d.ClientId,
                o => o.MapFrom(src => src.CustomerId));
            CreateMap<ProjectCreationDto, Project>().ForMember(
                d => d.Id,
                o => o.MapFrom(src => Guid.NewGuid()))
                .ForMember(
                d => d.Client,
                o => o.MapFrom(src => src.Customer))
                .ForMember(
                d => d.ClientId,
                o => o.MapFrom(src => src.CustomerId));
            CreateMap<ProjectUpdateDto, Project>()
                .ForMember(
                d => d.Client,
                o => o.MapFrom(src => src.Customer))
                .ForMember(
                d => d.ClientId,
                o => o.MapFrom(src => src.CustomerId));
            CreateMap<ProjectDto, ProjectConfirmationDto>();
            CreateMap<Project, ProjectConfirmationDto>();
            CreateMap<Project, ProjectDto>()
                .ForMember(
                d => d.Customer,
                o => o.MapFrom(src => src.Client))
                .ForMember(
                d => d.CustomerId,
                o => o.MapFrom(src => src.ClientId));
        }
    }
}
