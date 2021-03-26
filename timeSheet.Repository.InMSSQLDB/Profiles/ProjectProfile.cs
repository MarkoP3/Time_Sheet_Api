using AutoMapper;
using timeSheet.Repository.InMSSQLDB.EntitiesDB;

namespace timeSheet.Repository.InMSSQLDB.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, Contract.Entities.Project>()
                .ForMember(dest => dest.Lead,
                opt => opt.MapFrom(src => src.Lead.Name))
                .ForMember(dest => dest.Client,
                opt => opt.MapFrom(src => src.Client.Name));
            CreateMap<Contract.Entities.Project, Project>();
        }
    }
}
