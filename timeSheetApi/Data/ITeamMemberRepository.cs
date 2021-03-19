using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using timeSheetApi.Models;

namespace timeSheetApi.Data
{
    public interface ITeamMemberRepository
    {
        TeamMemberDto AddTeamMember(TeamMemberDto teamMember);
        TeamMemberDto UpdateTeamMember(TeamMemberDto teamMember);
        bool DeleteTeamMemeber(Guid teamMember);
        IList<TeamMemberDto> TeamMembersOnPage(int page, int recordPerPage);
        decimal NumberOfPages(int recordPerPage);
        IList<dynamic> AllTeamMembers();
    }
}
