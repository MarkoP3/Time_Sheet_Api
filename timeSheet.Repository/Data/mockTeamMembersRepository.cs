using System;
using System.Collections.Generic;
using System.Linq;
using timeSheet.Repository.Contract.Data;
using timeSheet.Repository.Contract.Entities;

namespace timeSheet.Repository.Data
{
    public class mockTeamMembersRepository : ITeamMemberRepository
    {
        IList<TeamMember> teamMembers = new List<TeamMember>();
        public mockTeamMembersRepository()
        {
            //teamMembers.Add(new TeamMember() { Id = Guid.Parse("42b667ab-d17b-4a8f-aa97-a3f5c62467c1"), Name = "Predrag Predragovic", Username = "username", HoursPerWeek = 40, Email = "predrag@gmail.com", Password = "neka hashovana vrednost", Salt = "jedinstvena hashovana vrednost", Role = "Admin", Status = "Active" });
        }
        public TeamMember AddTeamMember(TeamMember teamMember)
        {
            teamMember.Id = Guid.NewGuid();
            teamMembers.Add(teamMember);
            return teamMembers.First(el => el.Id == teamMember.Id);
        }

        public IList<TeamMember> AllTeamMembers()
        {
            return teamMembers;
        }

        public bool DeleteTeamMemeber(Guid teamMember)
        {
            teamMembers = teamMembers.Where((el) => el.Id != teamMember).ToList();
            return true;
        }

        public decimal MembersMaxHoursPerDay(Guid id)
        {
            return teamMembers.Where(el => el.Id == id).FirstOrDefault().HoursPerWeek / 5;
        }

        public decimal NumberOfPages(int recordPerPage)
        {
            return Math.Ceiling((decimal)teamMembers.Count() / recordPerPage);
        }

        public bool SaveChanges()
        {
            return true;
        }

        public IList<TeamMember> TeamMembersOnPage(int page, int recordPerPage)
        {
            return teamMembers.Skip(page * recordPerPage).Take(recordPerPage).ToList();
        }

        public TeamMember UpdateTeamMember(TeamMember teamMember)
        {
            var current = teamMembers.Where(el => el.Id == teamMember.Id).FirstOrDefault();
            var index = teamMembers.IndexOf(current);
            teamMembers[index] = teamMember;
            return teamMembers[index];
        }
    }
}
