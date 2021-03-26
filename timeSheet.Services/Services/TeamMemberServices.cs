using AutoMapper;
using System;
using System.Collections.Generic;
using timeSheet.Repository.Contract.Data;
using timeSheet.Repository.Contract.Entities;
using timeSheet.Services.Contract.Models;
using timeSheet.Services.Contract.Services;

namespace timeSheet.Services.Services
{
    public class TeamMemberServices : ITeamMemberServices
    {
        public TeamMemberServices(ITeamMemberRepository teamMemberRepository, IMapper mapper)
        {
            TeamMemberRepository = teamMemberRepository;
            Mapper = mapper;
        }

        public ITeamMemberRepository TeamMemberRepository { get; }
        public IMapper Mapper { get; }

        public TeamMemberDto AddTeamMember(TeamMemberDto teamMember)
        {
            TeamMemberRepository.AddTeamMember(new TeamMember(Guid.NewGuid(), teamMember.Name, teamMember.Email, teamMember.Username, "generisem password", teamMember.HoursPerWeek, "generisem salt", teamMember.Status, teamMember.Role));
            TeamMemberRepository.SaveChanges();
            return teamMember;
        }

        public IEnumerable<TeamMemberDto> AllTeamMembers()
        {
            return Mapper.Map<IList<TeamMemberDto>>(TeamMemberRepository.AllTeamMembers());
        }

        public bool DeleteTeamMemeber(Guid teamMember)
        {
            var isDeleted = TeamMemberRepository.DeleteTeamMemeber(teamMember);
            TeamMemberRepository.SaveChanges();
            return isDeleted;
        }

        public decimal MembersMaxHoursPerDay(Guid id)
        {
            return TeamMemberRepository.MembersMaxHoursPerDay(id);
        }

        public decimal NumberOfPages(int recordPerPage)
        {
            return TeamMemberRepository.NumberOfPages(recordPerPage);
        }

        public IEnumerable<TeamMemberDto> TeamMembersOnPage(int page, int recordPerPage)
        {
            return Mapper.Map<IEnumerable<TeamMemberDto>>(TeamMemberRepository.TeamMembersOnPage(page, recordPerPage));
        }

        public TeamMemberDto UpdateTeamMember(TeamMemberDto teamMember)
        {
            var updatedMember = TeamMemberRepository.UpdateTeamMember(Mapper.Map<TeamMember>(teamMember));
            TeamMemberRepository.SaveChanges();
            return Mapper.Map<TeamMemberDto>(updatedMember);
        }
    }
}
