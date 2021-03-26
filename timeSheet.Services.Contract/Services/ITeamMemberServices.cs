using System;
using System.Collections.Generic;
using timeSheet.Services.Contract.Models;

namespace timeSheet.Services.Contract.Services
{
    public interface ITeamMemberServices
    {
        public TeamMemberDto AddTeamMember(TeamMemberDto teamMember);

        public IEnumerable<TeamMemberDto> AllTeamMembers();

        public bool DeleteTeamMemeber(Guid teamMember);

        public decimal MembersMaxHoursPerDay(Guid id);
        public decimal NumberOfPages(int recordPerPage);

        public IEnumerable<TeamMemberDto> TeamMembersOnPage(int page, int recordPerPage);
        public TeamMemberDto UpdateTeamMember(TeamMemberDto teamMember);
    }
}
