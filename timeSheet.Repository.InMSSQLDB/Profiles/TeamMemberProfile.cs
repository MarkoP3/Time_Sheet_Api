using AutoMapper;
using timeSheet.Repository.InMSSQLDB.EntitiesDB;

namespace timeSheet.Repository.InMSSQLDB.Profiles
{
    public class TeamMemberProfile : Profile
    {
        public TeamMemberProfile()
        {
            CreateMap<TeamMember, Contract.Entities.TeamMember>();
            CreateMap<Contract.Entities.TeamMember, TeamMember>();
        }
    }
}
