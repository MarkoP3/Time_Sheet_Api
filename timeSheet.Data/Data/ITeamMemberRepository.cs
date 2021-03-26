using System;
using System.Collections.Generic;
using timeSheet.Common.Models;

namespace timeSheet.Data.Data
{
    public interface ITeamMemberRepository
    {
        TeamMemberDto AddTeamMember(TeamMemberDto teamMember);
        TeamMemberDto UpdateTeamMember(TeamMemberDto teamMember);
        bool DeleteTeamMemeber(Guid teamMember);
        IList<TeamMemberDto> TeamMembersOnPage(int page, int recordPerPage);
        decimal NumberOfPages(int recordPerPage);
        IList<dynamic> AllTeamMembers();
        decimal MembersMaxHoursPerDay(Guid id);
    }
}
