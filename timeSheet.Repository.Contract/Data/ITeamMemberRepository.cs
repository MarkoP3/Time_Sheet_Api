using System;
using System.Collections.Generic;
using timeSheet.Repository.Contract.Entities;

namespace timeSheet.Repository.Contract.Data
{
    public interface ITeamMemberRepository
    {
        TeamMember AddTeamMember(TeamMember teamMember);
        TeamMember UpdateTeamMember(TeamMember teamMember);
        bool DeleteTeamMemeber(Guid teamMember);
        IList<TeamMember> TeamMembersOnPage(int page, int recordPerPage);
        decimal NumberOfPages(int recordPerPage);
        IList<TeamMember> AllTeamMembers();
        decimal MembersMaxHoursPerDay(Guid id);
        bool SaveChanges();
    }
}
