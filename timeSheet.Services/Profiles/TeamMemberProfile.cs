using AutoMapper;
using timeSheet.Repository.Contract.Entities;
using timeSheet.Services.Contract.Models;

namespace timesheet.Services.Profiles
{
    class TeamMemberProfile : Profile
    {
        public TeamMemberProfile()
        {
            CreateMap<TeamMember, TeamMemberDto>();
            CreateMap<TeamMemberDto, TeamMember>();
        }
    }
}
