using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using timeSheetApi.Models;

namespace timeSheetApi.Data
{
    public class mockTeamMembersRepository : ITeamMemberRepository
    {
        IList<TeamMemberDto> teamMembers = new List<TeamMemberDto>();
        public mockTeamMembersRepository()
        {
            teamMembers.Add(new TeamMemberDto() { Id = Guid.Parse("42b667ab-d17b-4a8f-aa97-a3f5c62467c1"), Name ="Predrag Predragovic",Username="username",HoursPerWeek=40,Email="predrag@gmail.com",Password="neka hashovana vrednost",Salt="jedinstvena hashovana vrednost", Role="Admin",Status="Active" });
        }
        public TeamMemberDto AddTeamMember(TeamMemberDto teamMember)
        {
            teamMember.Id = Guid.NewGuid();
            teamMembers.Add(teamMember);
            return teamMembers.First(el => el.Id == teamMember.Id);
        }

        public IList<dynamic> AllTeamMembers()
        {
            List<dynamic> list = new List<dynamic>();
            foreach (var teamMember in teamMembers)
                list.Add(new { teamMember.Id, teamMember.Name });
            return list;
        }

        public bool DeleteTeamMemeber(Guid teamMember)
        {
            teamMembers = teamMembers.Where((el) => el.Id != teamMember).ToList();
            return true;
        }

        public decimal NumberOfPages(int recordPerPage)
        {
            return Math.Ceiling((decimal)teamMembers.Count() / recordPerPage);
        }

        public IList<TeamMemberDto> TeamMembersOnPage(int page, int recordPerPage)
        {
            return teamMembers.Skip(page * recordPerPage).Take(recordPerPage).ToList();
        }

        public TeamMemberDto UpdateTeamMember(TeamMemberDto teamMember)
        {
            var current = teamMembers.Where(el => el.Id == teamMember.Id).FirstOrDefault();
            var index = teamMembers.IndexOf(current);
            teamMembers[index] = teamMember;
            return teamMembers[index];
        }
    }
}
